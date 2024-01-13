    using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Effektive_Praesentationen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        { 
            IServiceCollection services = new ServiceCollection();  
            services.AddSingleton<MainWindow>();
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
