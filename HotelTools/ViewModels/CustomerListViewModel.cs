using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelTools.ViewModels
{
    public class CustomerListViewModel : ObservableObject
    {
        private readonly IDataBaseService _dataBaseService;
        private ObservableCollection<Customer> _customerDatagrid = new ObservableCollection<Customer>();
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private string _searchQuery = string.Empty;



        public CustomerListViewModel(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
            foreach (var customer in dataBaseService.GetAllCustomers())
            {
                Customers.Add(customer);
            }
            _customerDatagrid = new ObservableCollection<Customer>(Customers);

        }


        public ObservableCollection<Customer> CustomerDatagrid { get => _customerDatagrid; set => SetProperty(ref _customerDatagrid, value); }
        public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }
        public string SearchQuery
        {
            get => _searchQuery; set
            {
                CustomerDatagrid = new ObservableCollection<Customer>(from c in Customers
                   where (c.FirstName.Contains(value,System.StringComparison.InvariantCultureIgnoreCase) || c.LastName.Contains(value,System.StringComparison.InvariantCultureIgnoreCase) || c.NationalID.Contains(value,System.StringComparison.InvariantCultureIgnoreCase))
                                                                      select c);
                SetProperty(ref _searchQuery, value);
            }
        }
    }
}
