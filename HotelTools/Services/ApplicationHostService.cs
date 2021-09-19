using HotelTools.Core.Interfaces;
using HotelTools.Interfaces;
using HotelTools.Interfaces.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelTools.Services
{
    internal class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private bool _isInitialized;

        public ApplicationHostService(IServiceProvider serviceProvider, IDataBaseService dataBaseService, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
        }



        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _isInitialized = true;
            IMainWindow mainWindow= _serviceProvider.GetService(typeof(IMainWindow)) as IMainWindow;
            _navigationService.Initialize(mainWindow.GetMainFrame());
            mainWindow.Show();
            _navigationService.NavigateTo(typeof(ViewModels.CustomerListViewModel).FullName);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
