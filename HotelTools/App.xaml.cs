
using HotelTools.Interfaces;
using HotelTools.Interfaces.Services;
using HotelTools.Services;
using HotelTools.ViewModels;
using HotelTools.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace HotelTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            _host = Host.CreateDefaultBuilder(e.Args)
                        .ConfigureServices(ConfigureServices)
                        .Build();

            await _host.StartAsync();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHostedService<ApplicationHostService>();

            services.AddSingleton<Core.Interfaces.IDataBaseService, Core.Services.DataBaseService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<Core.Interfaces.IDataBaseService, Core.Services.DataBaseService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IDataStore, DataStore>();

            services.AddTransient<IMainWindow, MainWindow>();
            services.AddTransient<MainWindowViewModel>();


            services.AddTransient<CustomerListViewModel>();
            services.AddTransient<CustomerListView>();

            services.AddTransient<CustomerEditViewModel>();
            services.AddTransient<CustomerEditView>();


            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomeView>();

            services.AddTransient<RoomListViewModel>();
            services.AddTransient<RoomListView>();

            services.AddTransient<RoomEditViewModel>();
            services.AddTransient<RoomEditView>();
        }
    }
}
