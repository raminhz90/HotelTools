using HotelTools.Core.Interfaces;
using Microsoft.Extensions.Hosting;
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
        private bool _isInitialized;

        public ApplicationHostService(IServiceProvider serviceProvider,Core.Interfaces.IDataBaseService dataBaseService)
        {
            _serviceProvider = serviceProvider;
            _dataBaseService = dataBaseService;
        }



        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _isInitialized = true;
            MainWindow mainWindow= _serviceProvider.GetService(typeof(MainWindow)) as MainWindow;
            mainWindow.Show();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
