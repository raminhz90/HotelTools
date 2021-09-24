using HandyControl.Tools.Command;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelTools.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService; 
        }

        public RelayCommand HomeButtonCommand => new RelayCommand(new Action<object>(HomeButton));

        private void HomeButton(object obj)
        {
            _navigationService.NavigateTo(typeof(ViewModels.HomeViewModel).FullName);

        }
    }
}
