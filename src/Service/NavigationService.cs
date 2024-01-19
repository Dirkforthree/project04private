using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Effektive_Praesentationen.Core;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.ViewModel;

namespace Effektive_Praesentationen.Service
{
    public interface INavigationService
    {
        Core.ViewModel CurrentViewModel { get; }
        void NavigateTo<T>() where T : Core.ViewModel;
        void PathNavigateTo<T>(string filePath) where T : Core.ViewModel;
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
            if (CurrentViewModel is not null)
            {
                MainWindowViewModel mainViewModel = (MainWindowViewModel)_viewModelFactory.Invoke(typeof(MainWindowViewModel));
                mainViewModel.WindowTitle = viewModel.viewName;
            }
            CurrentViewModel = viewModel;
        }

        public void PathNavigateTo<TViewModel>(string filePath) where TViewModel : Core.ViewModel
        {
            Core.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            if (viewModel is IFileNavigableViewModel fileNavigableViewModel)
            {
                fileNavigableViewModel.SetFilePath(filePath);
            }

            CurrentViewModel = viewModel;
            MainWindowViewModel mainViewModel = (MainWindowViewModel)_viewModelFactory.Invoke(typeof(MainWindowViewModel));
            mainViewModel.WindowTitle = viewModel.viewName;
        }
    }
}
