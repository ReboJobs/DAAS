using System;
namespace BlazorDataAnalytics.Data
{
    public class FilterState
    {
        public bool IsShowHideFilter { get; set; }
        public string? curUrl { get; set; }

        public event Action OnChange;
        public event Action OnChangeFilter;
        public void SetFilter(bool filter)
        {
            IsShowHideFilter = filter;
            NotifyStateChanged();
        }

        public void SetFilterShow(string url)
        {
            curUrl = url;
            OnChangeFilter?.Invoke();

        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }

       
    }
}