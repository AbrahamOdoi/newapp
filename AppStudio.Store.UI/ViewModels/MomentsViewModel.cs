using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class MomentsViewModel : ViewModelBase<MomentsSchema>
    {
        static private MomentsViewModel _current = null;

        static public MomentsViewModel Current
        {
            get { return _current ?? (_current = new MomentsViewModel()); }
        }

        protected override string CacheKey
        {
            get { return "MomentsDataSource"; }
        }

        protected override IDataSource<MomentsSchema> CreateDataSource()
        {
            return new MomentsDataSource(); // StaticDataSource
        }

        protected override void NavigateToSelectedItem()
        {
            DisableSelectionNavigation();
            NavigationServices.NavigateToPage("MomentsViewDetail");
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
                    base.PinToStart("MomentsViewDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
                });
            }
        }
}
}
