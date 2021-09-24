using HandyControl.Tools.Command;
using HotelTools.Core.Interfaces;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelTools.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private readonly IDataStore _dataStore;

        public HomeViewModel(IDataBaseService dataBaseService, INavigationService navigationService, IDataStore dataStore)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            _dataStore = dataStore;
        }

        public RelayCommand GoCustomer => new RelayCommand(new Action<object>(goCustomer));

        private void goCustomer(object obj)
        {
            _navigationService.NavigateTo(typeof(ViewModels.CustomerListViewModel).FullName);
        }

        public RelayCommand Goroom => new RelayCommand(new Action<object>(goRoom));

        private void goRoom(object obj)
        {
            _navigationService.NavigateTo(typeof(ViewModels.RoomListViewModel).FullName);

        }
    }
}
