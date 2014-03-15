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
    public partial class WhoWeAreViewDetail
    {
        private NavigationHelper _navigationHelper;

        private WhoWeAreViewModel _whoWeAreViewModel = null;

        public WhoWeAreViewDetail()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            DataContext = WhoWeAreViewModel;
        }

        public WhoWeAreViewModel WhoWeAreViewModel
        {
            get { return _whoWeAreViewModel ?? (_whoWeAreViewModel = WhoWeAreViewModel.Current); }
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
            await WhoWeAreViewModel.LoadItems(true);
            DataContext = WhoWeAreViewModel;
            base.OnNavigatedTo(e);
        }
    }
}
