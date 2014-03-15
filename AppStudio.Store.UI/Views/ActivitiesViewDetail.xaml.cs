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
    public partial class ActivitiesViewDetail
    {
        private NavigationHelper _navigationHelper;

        private ActivitiesViewModel _activitiesViewModel = null;

        public ActivitiesViewDetail()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            DataContext = ActivitiesViewModel;
        }

        public ActivitiesViewModel ActivitiesViewModel
        {
            get { return _activitiesViewModel ?? (_activitiesViewModel = ActivitiesViewModel.Current); }
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
            await ActivitiesViewModel.LoadItems(true);
            DataContext = ActivitiesViewModel;
            base.OnNavigatedTo(e);
        }
    }
}
