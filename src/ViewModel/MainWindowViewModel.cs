using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Effektive_Praesentationen.Model;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Core;
using System.Diagnostics;
using Effektive_Praesentationen.Service;

namespace Effektive_Praesentationen.ViewModel
{

    public partial class MainWindowViewModel : Core.ViewModel
    {

        [ObservableProperty]
        private INavigationService _navigation;

        [ObservableProperty]
        private string _windowTitle="FileSelection";

        public MainWindowViewModel(INavigationService navService)
        {
            Navigation = navService;
            Navigation.NavigateTo<FileSelectionViewModel>();
        }

    }
}
