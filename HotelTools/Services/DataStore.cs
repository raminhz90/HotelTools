using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace HotelTools.Services
{
    public class DataStore : IDataStore
    {
        private Customer _customer =null;

        public Customer GetCustomer() => _customer;

        public void setCustomer(Customer customer) => _customer = customer;

        public DataStore(IServiceProvider serviceProvider)
        {

        }

    }
}
