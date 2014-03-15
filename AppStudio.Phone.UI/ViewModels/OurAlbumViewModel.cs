using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class OurAlbumViewModel : ViewModelBase<OurAlbumSchema>
    {
        override protected string CacheKey
        {
            get { return "OurAlbumDataSource"; }
        }

        override protected IDataSource<OurAlbumSchema> CreateDataSource()
        {
            return new OurAlbumDataSource(); // StaticDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("OurAlbumViewDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}", "{DefaultImageUrl}");
        }

        override public bool IsSpeakTextVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void SpeakText()
        {
            base.SpeakText("Subtitle");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("OurAlbumViewDetail");
        }
    }
}
