using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

using AppStudio.Data;

namespace AppStudio
{
    public sealed partial class MainPage
    {
        private bool _isLoadingData = false;

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

 
        public WhoWeAreViewModel WhoWeAreViewModel
        {
            get { return WhoWeAreViewModel.Current; }
        }
 
        public OurAlbumViewModel OurAlbumViewModel
        {
            get { return OurAlbumViewModel.Current; }
        }
 
        public ActivitiesViewModel ActivitiesViewModel
        {
            get { return ActivitiesViewModel.Current; }
        }
 
        public MomentsViewModel MomentsViewModel
        {
            get { return MomentsViewModel.Current; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            AppLogs.WriteInfo("OnNavigatedTo", e.NavigationMode.ToString());

            _isLoadingData = true;
            ShowProgressBarOnTimeElapsed();
            await EnsureDataLoaded();
            _isLoadingData = false;
            progressBar.Visibility = Visibility.Collapsed;

            EnableSelectionNavigation();

            //ReadLogs();
        }

        private async Task EnsureDataLoaded()
        {
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            var loadTasks = new Task[] {
                WhoWeAreViewModel.LoadItems(isNetworkAvailable),
                OurAlbumViewModel.LoadItems(isNetworkAvailable),
                ActivitiesViewModel.LoadItems(isNetworkAvailable),
                MomentsViewModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        private void EnableSelectionNavigation()
        {
            WhoWeAreViewModel.EnableSelectionNavigation();
            OurAlbumViewModel.EnableSelectionNavigation();
            ActivitiesViewModel.EnableSelectionNavigation();
            MomentsViewModel.EnableSelectionNavigation();
        }

        private void ShowProgressBarOnTimeElapsed()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += OnTimeElapsed;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Start();
        }

        private void OnTimeElapsed(object sender, object e)
        {
            DispatcherTimer timer = sender as DispatcherTimer;
            timer.Stop();
            timer.Tick -= OnTimeElapsed;
            if (_isLoadingData)
            {
                progressBar.Visibility = Visibility.Visible;
            }
        }
    }
}
