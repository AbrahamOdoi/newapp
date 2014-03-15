using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private WhoWeAreViewModel _whoWeAreViewModel;
       private OurAlbumViewModel _ourAlbumViewModel;
       private ActivitiesViewModel _activitiesViewModel;
       private MomentsViewModel _momentsViewModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModels()
        {
            _selectedItem = WhoWeAreViewModel;
        }
 
        public WhoWeAreViewModel WhoWeAreViewModel
        {
            get { return _whoWeAreViewModel ?? (_whoWeAreViewModel = new WhoWeAreViewModel()); }
        }
 
        public OurAlbumViewModel OurAlbumViewModel
        {
            get { return _ourAlbumViewModel ?? (_ourAlbumViewModel = new OurAlbumViewModel()); }
        }
 
        public ActivitiesViewModel ActivitiesViewModel
        {
            get { return _activitiesViewModel ?? (_activitiesViewModel = new ActivitiesViewModel()); }
        }
 
        public MomentsViewModel MomentsViewModel
        {
            get { return _momentsViewModel ?? (_momentsViewModel = new MomentsViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            WhoWeAreViewModel.ViewType = viewType;
            OurAlbumViewModel.ViewType = viewType;
            ActivitiesViewModel.ViewType = viewType;
            MomentsViewModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == WhoWeAreViewModel)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsLockScreenVisible
        {
            get { return SelectedItem == null || SelectedItem == WhoWeAreViewModel; }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == WhoWeAreViewModel; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsLockScreenVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                WhoWeAreViewModel.LoadItems(isNetworkAvailable),
                OurAlbumViewModel.LoadItems(isNetworkAvailable),
                ActivitiesViewModel.LoadItems(isNetworkAvailable),
                MomentsViewModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("LockScreenImage.jpg");
                });
            }
        }
    }
}
