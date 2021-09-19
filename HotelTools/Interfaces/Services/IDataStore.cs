using HotelTools.Core.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelTools.Interfaces.Services
{
    public interface IDataStore
    {
        Customer GetCustomer();
        void setCustomer(Customer customer);

    }
}
