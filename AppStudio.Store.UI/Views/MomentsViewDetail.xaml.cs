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
    public partial class MomentsViewDetail
    {
        private NavigationHelper _navigationHelper;

        private MomentsViewModel _momentsViewModel = null;

        public MomentsViewDetail()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            DataContext = MomentsViewModel;
        }

        public MomentsViewModel MomentsViewModel
        {
            get { return _momentsViewModel ?? (_momentsViewModel = MomentsViewModel.Current); }
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
            await MomentsViewModel.LoadItems(true);
            DataContext = MomentsViewModel;
            base.OnNavigatedTo(e);
        }
    }
}
