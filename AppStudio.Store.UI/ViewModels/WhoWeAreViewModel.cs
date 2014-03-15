using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class WhoWeAreViewModel : ViewModelBase<WhoWeAreSchema>
    {
        static private WhoWeAreViewModel _current = null;

        static public WhoWeAreViewModel Current
        {
            get { return _current ?? (_current = new WhoWeAreViewModel()); }
        }

        protected override string CacheKey
        {
            get { return "WhoWeAreDataSource"; }
        }

        protected override IDataSource<WhoWeAreSchema> CreateDataSource()
        {
            return new WhoWeAreDataSource(); // StaticDataSource
        }

        protected override void NavigateToSelectedItem()
        {
            DisableSelectionNavigation();
            NavigationServices.NavigateToPage("WhoWeAreViewDetail");
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
                    base.PinToStart("WhoWeAreViewDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
                });
            }
        }
}
}
