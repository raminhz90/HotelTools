using HandyControl.Tools.Command;
using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelTools.ViewModels
{
    public class CustomerListViewModel : ObservableObject
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private readonly IDataStore _dataStore;
        private ObservableCollection<Customer> _customerDatagrid = new ObservableCollection<Customer>();
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private string _searchQuery = string.Empty;
        private bool test = false;
        private Customer _selectedCustomer;


        public RelayCommand StartAllAccounts => new RelayCommand(new Action<object>(StartAllAccountsCommand), new Func<object, bool>(getCanex));
        public ObservableCollection<Customer> CustomerDatagrid { get => _customerDatagrid; set => SetProperty(ref _customerDatagrid, value); }
        public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }
        public string SearchQuery
        {
            get => _searchQuery; set
            {
                CustomerDatagrid = new ObservableCollection<Customer>(from c in Customers
                                                                      where (c.FirstName.Contains(value, System.StringComparison.InvariantCultureIgnoreCase) || c.LastName.Contains(value, System.StringComparison.InvariantCultureIgnoreCase) || c.NationalID.Contains(value, System.StringComparison.InvariantCultureIgnoreCase))
                                                                      select c);
                SetProperty(ref _searchQuery, value);
            }
        }
        public Customer SelectedCustomer { get => _selectedCustomer; set => SetProperty(ref _selectedCustomer, value); }



        private bool getCanex(object g)
        {
            if (SelectedCustomer != null)
            {
                return true;

            }
            else return true;


        }

        private void StartAllAccountsCommand(object g)
        {
            _dataStore.setCustomer(SelectedCustomer);
            _navigationService.NavigateTo(typeof(ViewModels.CustomerEditViewModel).FullName);
        }

        public CustomerListViewModel(IDataBaseService dataBaseService, INavigationService navigationService, IDataStore dataStore)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            _dataStore = dataStore;
            foreach (var customer in dataBaseService.GetAllCustomers())
            {
                Customers.Add(customer);
            }
            _customerDatagrid = new ObservableCollection<Customer>(Customers);
            //WeakReferenceMessenger.Default.Register<LoggedInUserChangedMessage>();

        }


    }
}
