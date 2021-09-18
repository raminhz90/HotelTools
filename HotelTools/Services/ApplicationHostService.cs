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
        private bool _isInitialized;

        public ApplicationHostService()
        {

        }



        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _isInitialized = true;
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
