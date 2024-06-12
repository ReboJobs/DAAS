using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Enums;

namespace BlazorDataAnalytics.Services.IdeaService
{
	public class IdeaService : IIdeaService
	{
		private readonly DataAnalyticsDBContext _db;
		private readonly IConfiguration _config;

		public IdeaService(
		DataAnalyticsDBContext db,
		IConfiguration config)
		{
			_db = db;
			_config = config;
		}

		public async Task<IdeaModel> UpsertIdeasAsync(IdeaModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var ideaDb = context.Ideas.Where(x => x.Id == model.Id).FirstOrDefault();

				if (ideaDb != null)
				{
					ideaDb.Title = model.Title;
					ideaDb.Description = model.Description;
					ideaDb.ImageBlobURL = model.ImageBlobURL;
				}
				else
				{
					ideaDb = new Idea
					{
						Title = model.Title,
						Description = model.Description,
						DateCreated = model.DateCreated,
						SubmittedBy = model.SubmittedBy,
						IsActive = true,
						ImageBlobURL = model.ImageBlobURL,
					};

					context.Ideas.Add(ideaDb);
				}

				await context.SaveChangesAsync();
				model.Id = ideaDb.Id;

				return model;
			}
		}
		public async Task UpsertIdeasImageBlobUrlAsync(int ideaId, string imageUrl)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var ideaDb = context.Ideas.Where(x => x.Id == ideaId).FirstOrDefault();

				if (ideaDb != null)
				{
					ideaDb.ImageBlobURL = imageUrl;
				}

				await context.SaveChangesAsync();
			}
		}

		public async Task<IdeaVoteModel> VoteIdeaAsync(IdeaVoteModel model)
		{
			try
            {
				using (var context = new DataAnalyticsDBContext())
				{

					var ideaVoteDb = context.IdeaVoteDetails.Where(x => x.IdeaId == model.IdeadId && x.VotedBy == model.VotedBy).FirstOrDefault();

					if (ideaVoteDb != null)
					{
						ideaVoteDb.IsActive = model.IsActive;
					}
					else
					{
						ideaVoteDb = new IdeaVoteDetail
						{
							VotedBy = model.VotedBy,
							IdeaId = model.IdeadId,
							DateVoted = model.DateVoted,
							IsActive = model.IsActive,
						};

						context.IdeaVoteDetails.Add(ideaVoteDb);
					}

					await context.SaveChangesAsync();
					model.Id = ideaVoteDb.Id;

					return model;
				}

			}
			catch(Exception ex)
            {
				return null;
            }

		}



		public async Task<List<IdeaModel>> SearchSubmitIdeaListAsync(IdeaSearchModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var ideaModel = context.Ideas
			.Where(s => (s.DateCreated >= model.DateFrom && s.DateCreated <= model.DateTo)
					 && s.IsActive == true
					 && (s.Title.Contains(model.Text) || s.Description.Contains(model.Text) || string.IsNullOrEmpty(model.Text)))
			.Select(x => new IdeaModel
			{
				Id = x.Id,
				Title = x.Title ?? String.Empty,
				Description = x.Description ?? String.Empty,
				DateCreated = x.DateCreated,
				SubmittedBy = x.SubmittedBy ?? String.Empty,
				IsUserVoted = context.IdeaVoteDetails.Where(i => i.IdeaId == x.Id && i.VotedBy == model.UserName && x.IsActive == true).FirstOrDefault() != null,
				TotalVotes = context.IdeaVoteDetails.Where(i => i.IdeaId == x.Id && x.IsActive == true).Count(),
				IsActive = x.IsActive,
				ImageBlobURL = x.ImageBlobURL ?? String.Empty
			}).OrderByDescending(x => x.DateCreated).ToList();

				return ideaModel;
			}
		}

		public async Task DeleteIdeaAsync(int ideaId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var ideaDb = context.Ideas.Where(x => x.Id == ideaId).FirstOrDefault();

				if (ideaDb != null)
				{
					ideaDb.IsActive = false;
					await context.SaveChangesAsync();
				}
			}
		}

	}
}