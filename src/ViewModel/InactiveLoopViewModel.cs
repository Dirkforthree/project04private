using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Effektive_Praesentationen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.Input;
using System.Windows.Input;
using Effektive_Praesentationen.Model;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Core;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Dynamic;
using System.Windows.Media;
using System.Windows;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class InactiveLoopViewModel : Core.ViewModel
    {

        [ObservableProperty]
        private INavigationService _navigation;

        private string? _filePath;

        public string? FilePath
        {
            get { return _filePath; }
            set
            {
                if (SetProperty(ref _filePath, value))
                {
                    //Change the path to a URI and update the URI-attribute
                    UpdateUri();
                }
            }
        }

        //URI,in order that it is taken as Source in View
        private Uri? _fileUri;

        public Uri? FileUri
        {
            get { return _fileUri; }
            private set { SetProperty(ref _fileUri, value); }
        }

        private void UpdateUri()
        {
            try
            {
                FileUri = new Uri(FilePath, UriKind.RelativeOrAbsolute);
            }
            catch (UriFormatException)
            {
                // handle a invalid URI-Format exception here, if neccesary
                FileUri = null;
            }
        }

        [RelayCommand]
        public void NavigateToFileSelection()
        {
            Navigation.NavigateTo<FileSelectionViewModel>();
        }

        public InactiveLoopViewModel(INavigationService navService)
        {
            Navigation = navService;
        }
    }
}
