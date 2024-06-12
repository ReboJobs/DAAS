using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.BlobStorageService;
using BlazorDataAnalytics.Services.UserReportCardImageService;
using BlazorDataAnalytics.Services.UserThemeSettingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BlazorDataAnalytics.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IUserReportCardImageService _userReportCardImageService;
        private readonly IUserThemeSettingService _userThemeSettingService;

        private readonly string imageContainer = "images";
        private readonly string defaultDirectory = "default";


        public FileController(ILogger<FileController> logger,
                             IBlobStorageService blobStorageService,
                             IUserReportCardImageService userReportCardImageService,
                             IUserThemeSettingService userThemeSettingService)
        {
            _logger = logger;
            _blobStorageService = blobStorageService;
            _userReportCardImageService = userReportCardImageService;
            _userThemeSettingService = userThemeSettingService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async void UploadCardPicture(IList<IFormFile> UploadFiles, int ReportDBID)
        {
            try
            {
                string userName = User?.Identity?.Name ?? string.Empty;

                foreach (var file in UploadFiles)
                {
                    if (file.Length > 0 && ReportDBID > 0 && !string.IsNullOrEmpty(userName))
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            var fileUploadModel = new FileUploadModel
                            {
                                FileName = file.FileName,
                                FileMimeType = file.ContentType,
                                FileByte = fileBytes,
                                Container = imageContainer,
                                SubDirectory = User?.Identity?.Name ?? defaultDirectory
                            };

                           string imageBlobUrl = _blobStorageService.UploadFileToBlob(fileUploadModel).Result;

                            if (!string.IsNullOrEmpty(imageBlobUrl))
                            {
                                var UserReportCardImageModel = new UserReportCardImageModel
                                {
                                    ReportDBID = ReportDBID,
                                    ImageBlobURL = imageBlobUrl,
                                    UserName = userName,
                                    DateCreated = DateTime.Now,
                                    DateUpdated = DateTime.Now,
                                };

                                var existImageUrl = _userReportCardImageService.GetUserReportCardImagesByReportDBIDAsync(ReportDBID).Result;
                                if (existImageUrl != null)
                                {
                                    _ = _blobStorageService.DeleteBlobData(existImageUrl?.ImageBlobURL ?? string.Empty, 
                                                                            imageContainer, 
                                                                            User?.Identity?.Name ?? defaultDirectory).ConfigureAwait(true);
                                }

                               var resultModel = _userReportCardImageService.UpsertUserReportCardImagesAsync(UserReportCardImageModel).Result;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid File Byte Or User Name...");
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }

        [HttpPost("[action]")]
        public async void UploadUserHeaderLogo(IList<IFormFile> UploadLogo)
        {
            try
            {
                string userName = User?.Identity?.Name ?? string.Empty;

                foreach (var file in UploadLogo)
                {
                    if (file.Length > 0 && !string.IsNullOrEmpty(userName))
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            var fileUploadModel = new FileUploadModel
                            {
                                FileName = file.FileName,
                                FileMimeType = file.ContentType,
                                FileByte = fileBytes,
                                Container = imageContainer,
                                SubDirectory = User?.Identity?.Name ?? defaultDirectory
                            };

                            string imageBlobUrl = _blobStorageService.UploadFileToBlob(fileUploadModel).Result;
                            var existImageUrl = _userThemeSettingService.GetUserThemeSettings(userName);
                            if (existImageUrl != null)
                            {
                                _ = _blobStorageService.DeleteBlobData(existImageUrl?.HeaderImageLogoUrl ?? string.Empty,
                                                                        imageContainer,
                                                                        User?.Identity?.Name ?? defaultDirectory).ConfigureAwait(true);
                            }
                            _ = _userThemeSettingService.UpdateUserImagesHeaderLogo(userName, imageBlobUrl).Result;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid File Byte Or User Name...");
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }

        [HttpPost("[action]")]
        public async void UploadUserBackgroundImage(IList<IFormFile> BackgroundImage)
        {
            try
            {
                string userName = User?.Identity?.Name ?? string.Empty;

                foreach (var file in BackgroundImage)
                {
                    if (file.Length > 0 && !string.IsNullOrEmpty(userName))
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            var fileUploadModel = new FileUploadModel
                            {
                                FileName = file.FileName,
                                FileMimeType = file.ContentType,
                                FileByte = fileBytes,
                                Container = imageContainer,
                                SubDirectory = User?.Identity?.Name ?? defaultDirectory
                            };

                            string imageBlobUrl = _blobStorageService.UploadFileToBlob(fileUploadModel).Result;
                            var existImageUrl = _userThemeSettingService.GetUserThemeSettings(userName);
                            if (existImageUrl != null)
                            {
                                _ = _blobStorageService.DeleteBlobData(existImageUrl?.BackgroundImageLogoUrl ?? string.Empty,
                                                                        imageContainer,
                                                                        User?.Identity?.Name ?? defaultDirectory).ConfigureAwait(true);
                            }
                            _ = _userThemeSettingService.UpdateUserBackgroundImages(userName, imageBlobUrl).Result;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid File Byte Or User Name...");
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }



        [HttpPost("[action]")]
        public async void UploadUserIdeaImage(IList<IFormFile> UploadFiles)
        {
            try
            {
                string userName = User?.Identity?.Name ?? string.Empty;

                foreach (var file in UploadFiles)
                {
                    if (file.Length > 0 && !string.IsNullOrEmpty(userName))
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            var fileUploadModel = new FileUploadModel
                            {
                                FileName = file.FileName,
                                FileMimeType = file.ContentType,
                                FileByte = fileBytes,
                                Container = imageContainer,
                                SubDirectory = User?.Identity?.Name ?? defaultDirectory
                            };

                            string imageBlobUrl = _blobStorageService.UploadFileToBlob(fileUploadModel).Result;
                      
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid File Byte Or User Name...");
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }


    }
}