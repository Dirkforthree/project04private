    using System.Configuration;
using System.Data;
using System.Windows;
using Effektive_Praesentationen.Service;
using Effektive_Praesentationen.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Effektive_Praesentationen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        { 
            IServiceCollection services = new ServiceCollection();  
            services.AddSingleton<MainWindow>(provider => new MainWindow() { 
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<FileSelectionViewModel>();
            services.AddSingleton<InactiveLoopViewModel>();
            services.AddSingleton<INavigationService,NavigationService>();
            services.AddSingleton<Func<Type,Core.ViewModel>>(serviceProvider => viewModelType => (Core.ViewModel) serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider=services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
