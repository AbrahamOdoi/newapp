using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class ActivitiesViewModel : ViewModelBase<ActivitiesSchema>
    {
        static private ActivitiesViewModel _current = null;

        static public ActivitiesViewModel Current
        {
            get { return _current ?? (_current = new ActivitiesViewModel()); }
        }

        protected override string CacheKey
        {
            get { return "ActivitiesDataSource"; }
        }

        protected override IDataSource<ActivitiesSchema> CreateDataSource()
        {
            return new ActivitiesDataSource(); // StaticDataSource
        }

        protected override void NavigateToSelectedItem()
        {
            DisableSelectionNavigation();
            NavigationServices.NavigateToPage("ActivitiesViewDetail");
        }

        public ICommand ShareTextCommand
        {
            get
            {
                return new RelayCommand<string>((fields) =>
                {
                    base.ShareItem("{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}", "{DefaultImageUrl}");
                });
            }
        }

        public ICommand PinToStartCommand
        {
            get
            {
                return new RelayCommand<string>((fields) =>
                {
                    base.PinToStart("ActivitiesViewDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
                });
            }
        }
}
}
