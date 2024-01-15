using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Effektive_Praesentationen.Core;

namespace Effektive_Praesentationen.Service
{
    public interface INavigationService
    {
        Core.ViewModel CurrentViewModel { get; }
        void NavigateTo<T>() where T : Core.ViewModel;
    }
    
    public partial class NavigationService : ObservableRecipient, INavigationService
    {
        [ObservableProperty]
        private Core.ViewModel? _currentViewModel;
        private readonly Func<Type, Core.ViewModel>? _viewModelFactory;

        

        public NavigationService(Func<Type, Core.ViewModel>? viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : Core.ViewModel
        {
            Core.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
    }
}
