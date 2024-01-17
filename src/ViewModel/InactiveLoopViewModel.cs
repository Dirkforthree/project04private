using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Effektive_Praesentationen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class InactiveLoopViewModel : Core.ViewModel
    {

        [ObservableProperty]
        private INavigationService _navigation;

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
