using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

using AppStudio.Data;
using AppStudio.Common;

namespace AppStudio
{
    public partial class OurAlbumViewDetail
    {
        private NavigationHelper _navigationHelper;

        private OurAlbumViewModel _ourAlbumViewModel = null;

        public OurAlbumViewDetail()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            DataContext = OurAlbumViewModel;
        }

        public OurAlbumViewModel OurAlbumViewModel
        {
            get { return _ourAlbumViewModel ?? (_ourAlbumViewModel = OurAlbumViewModel.Current); }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this._navigationHelper; }
        }

        override protected async void OnNavigatedTo(NavigationEventArgs e)
        {
            await OurAlbumViewModel.LoadItems(true);
            DataContext = OurAlbumViewModel;
            base.OnNavigatedTo(e);
        }
    }
}
