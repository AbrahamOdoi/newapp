using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Microsoft.Phone.Controls;

using MyToolkit.Paging;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class ActivitiesViewDetail
    {
        private bool _isDeepLink = false;

        public ActivitiesViewDetail()
        {
            InitializeComponent();
        }

        public ActivitiesViewModel ActivitiesViewModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ActivitiesViewModel = NavigationServices.CurrentViewModel as ActivitiesViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    ActivitiesViewModel = new ActivitiesViewModel();
                    NavigationServices.CurrentViewModel = ActivitiesViewModel;
                    ActivitiesViewModel.LoadItem(id);
                }
            }
            if (ActivitiesViewModel != null)
            {
                ActivitiesViewModel.ViewType = ViewTypes.Detail;
            }
            DataContext = ActivitiesViewModel;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationServices.CurrentViewModel = null;
            }
            SpeechServices.Stop();
            base.OnNavigatedFrom(e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeechServices.Stop();
        }
    }
}
