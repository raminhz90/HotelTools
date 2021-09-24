using HandyControl.Controls;
using HandyControl.Data;
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
        private Customer _selectedCustomer;


        public RelayCommand AddNewCustomerCommand => new RelayCommand(new Action<object>(AddNewCustomer));
        public RelayCommand EditCustomerCommand => new RelayCommand(new Action<object>(EditCustomer), new Func<object, bool>(IsSelectionValid));
        public RelayCommand DeleteCustomerCommand => new RelayCommand(new Action<object>(DeleteCustomer), new Func<object, bool>(IsSelectionValid));

        private void DeleteCustomer(object obj)
        {
            System.Windows.MessageBoxResult result =MessageBox.Show(new MessageBoxInfo
            {
                Message=$"Are you Sure You Want to Delete This Customer {_selectedCustomer.FirstName} {_selectedCustomer.LastName}",
                Button=System.Windows.MessageBoxButton.YesNo,
                
                
            });
            if (result.Equals(System.Windows.MessageBoxResult.Yes))
            {
                _dataBaseService.DeleteCustomer(_selectedCustomer);

            }
        }

        private void EditCustomer(object obj)
        {
            _dataStore.setCustomer(SelectedCustomer);
            _navigationService.NavigateTo(typeof(ViewModels.CustomerEditViewModel).FullName);
        }

        private void AddNewCustomer(object obj)
        {
            _dataStore.setCustomer(new Customer());
            _navigationService.NavigateTo(typeof(CustomerEditViewModel).FullName);
        }

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



        private bool IsSelectionValid(object g)
        {
            if (SelectedCustomer != null && SelectedCustomer.Id !=0)
            {
                return true;

            }
            else return false;


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

        }


    }
}
