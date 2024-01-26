using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Effektive_Praesentationen.Model;
using System.Runtime.InteropServices;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class FileSelectionViewModel : Core.ViewModel, IFilesDropped, IOpenFileDialog
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FileValid))]
        [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        private Chapters _chapters;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FileValid))]
        [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        private string test;
        //should we working without the "Test" variable, because it should reevalaute the FileValid property and CanExecute when changing the
        //value of Chapters.DefaultChapter
        //--> [NotifyPropertyChangedFor(nameof(FileValid))] and [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        //but it only works if i add a other variable and change the value there

        [ObservableProperty]
        private INavigationService _navigation;

        public FileSelectionViewModel(INavigationService navService)
        {
            Chapters = new Model.Chapters();
            Navigation = navService;
            viewName = "FileSelection";
        }

        [RelayCommand(CanExecute = nameof(FileValid))]
        public void NavigateToInactiveLoop()
        {
            Navigation.PathNavigateTo<InactiveLoopViewModel>(Chapters.DefaultChapter);

            if (Navigation.CurrentViewModel is InactiveLoopViewModel inactiveLoopViewModel)
            {
                inactiveLoopViewModel.FilePath = Chapters.DefaultChapter;
            }
        }

        public bool FileValid
        {
            get
            {
                if (String.IsNullOrEmpty(Chapters.DefaultChapter))
                {
                    return false;
                }
                string fileExtension = Path.GetExtension(Chapters.DefaultChapter);
                if (!(fileExtension == ".mp4" || fileExtension == ".mkv" || fileExtension == ".mov"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public void OnFilesDropped(string[] files)
        {
            Chapters.DefaultChapter = files[0];
            Test = files[0];
        }

        public void OnFileSelected(string[] files)
        {
            Chapters.DefaultChapter = files[0];
            Test = files[0];
        }


    }
}
