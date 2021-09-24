using HandyControl.Tools.Command;
using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;

namespace HotelTools.ViewModels
{
    public class CustomerEditViewModel : ObservableObject
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private Customer _customer;


        public RelayCommand CancelCommand => new RelayCommand(new Action<object>(CancelMethod));

        private void CancelMethod(object obj)
        {
            _navigationService.NavigateTo(typeof(ViewModels.CustomerListViewModel).FullName);
        }

        public RelayCommand DeleteCustomerComand => new RelayCommand(new Action<object>(DeleteCustomer), new Func<object, bool>(DeleteCustomerCanExecute));

        private bool DeleteCustomerCanExecute(object arg)
        {
            if (_customer == null || _customer.Id == 0)
            {
                return false;
            }
            return true;
        }

        public RelayCommand NewCustomerCommand => new RelayCommand(new Action<object>(NewCustomer));

        private void NewCustomer(object obj)
        {
            Customer=new Customer();
        }

        private void DeleteCustomer(object obj)
        {

            _dataBaseService.DeleteCustomer(_customer);
            _navigationService.NavigateTo(typeof(ViewModels.CustomerListViewModel).FullName);

        }

        public RelayCommand SaveCustomerCommand => new RelayCommand(new Action<object>(SaveCustomer), new Func<object, bool>(SaveCustomerCanExecute));

        private bool SaveCustomerCanExecute(object arg)
        {
            //TODO: Validation Check
            return true;
        }

        private void SaveCustomer(object obj)
        {
            _dataBaseService.SaveCustomer(_customer);
            _navigationService.NavigateTo(typeof(ViewModels.CustomerListViewModel).FullName);
        }

        public Customer Customer { get => _customer; set => SetProperty(ref _customer, value); }






        public CustomerEditViewModel(IDataBaseService dataBaseService, INavigationService navigationService, IDataStore dataStore)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            _customer = dataStore.GetCustomer();
        }



    }
}
