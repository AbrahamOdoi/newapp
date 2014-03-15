using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class OurAlbumViewModel : ViewModelBase<OurAlbumSchema>
    {
        static private OurAlbumViewModel _current = null;

        static public OurAlbumViewModel Current
        {
            get { return _current ?? (_current = new OurAlbumViewModel()); }
        }

        protected override string CacheKey
        {
            get { return "OurAlbumDataSource"; }
        }

        protected override IDataSource<OurAlbumSchema> CreateDataSource()
        {
            return new OurAlbumDataSource(); // StaticDataSource
        }

        protected override void NavigateToSelectedItem()
        {
            DisableSelectionNavigation();
            NavigationServices.NavigateToPage("OurAlbumViewDetail");
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
                    base.PinToStart("OurAlbumViewDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
                });
            }
        }
}
}
