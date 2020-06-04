using Microsoft.Extensions.DependencyInjection;
using TacsofonObj.ApplicationServices.GetPlatnostListUseCase;
using TacsofonObj.ApplicationServices.Ports.Cache;
using TacsofonObj.ApplicationServices.Repositories;
using TacsofonObj.DesktopClient.InfrastructureServices.ViewModels;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using TacsofonObj.InfrastructureServices.Cache;
using TacsofonObj.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TacsofonObj.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<tacsofonObj>, DomainObjectsMemoryCache<tacsofonObj>>();
            services.AddSingleton<NetworkTacsofonObjRepository>(
                x => new NetworkTacsofonObjRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<tacsofonObj>>())
            );
            services.AddSingleton<CachedReadOnlyTacsofonObjRepository>(
                x => new CachedReadOnlyTacsofonObjRepository(
                    x.GetRequiredService<NetworkTacsofonObjRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<tacsofonObj>>()
                )
            );
            services.AddSingleton<IReadOnlyTacsofonObjRepository>(x => x.GetRequiredService<CachedReadOnlyTacsofonObjRepository>());
            services.AddSingleton<IGetTacsofonObjListUseCase, GetTacsofonObjListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
