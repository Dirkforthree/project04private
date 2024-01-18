using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class FileSelectionViewModel : Core.ViewModel, IFilesDropped
    {
        [ObservableProperty]
        private Model.Chapters _chapters;

        [ObservableProperty]
        private INavigationService _navigation;

        public FileSelectionViewModel(INavigationService navService)
        {
            Chapters = new Model.Chapters();
            Navigation = navService;
        }

        [RelayCommand]
        public void NavigateToInactiveLoop()
        {
            Navigation.NavigateTo<InactiveLoopViewModel>();
        }

        [RelayCommand]
        public void ChaptersSetDefaultChapter(string path)
        {
            // TODO: Make sure path is correct
            Chapters.DefaultChapter = path;
        }

        public void OnFilesDropped(string[] files)
        {
            ChaptersSetDefaultChapter(files[0]);
        }

       
    }
}
