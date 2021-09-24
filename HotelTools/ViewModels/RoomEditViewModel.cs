using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Command;
using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelTools.ViewModels
{
    public class RoomEditViewModel : ObservableObject
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private Room _room;


        public RelayCommand CancelCommand => new RelayCommand(new Action<object>(CancelMethod));

        private void CancelMethod(object obj)
        {

            _navigationService.NavigateTo(typeof(ViewModels.RoomListViewModel).FullName);
        }

        public RelayCommand DeleteRoomComand => new RelayCommand(new Action<object>(DeleteRoom), new Func<object, bool>(DeleteRoomCanExecute));

        private bool DeleteRoomCanExecute(object arg)
        {
            if (_room == null || _room.Id == 0)
            {
                return false;
            }
            return true;
        }

        public RelayCommand NewRoomCommand => new RelayCommand(new Action<object>(NewRoom));

        private void NewRoom(object obj)
        {

            Room = new Room();
        }

        private void DeleteRoom(object obj)
        {

            var result = MessageBox.Show(new MessageBoxInfo
            {
                Message = $"Are you Sure You Want to Delete This Room ",
                Button = System.Windows.MessageBoxButton.YesNo,


            });
            if (result.Equals(System.Windows.MessageBoxResult.Yes))
            {
                _dataBaseService.DeleteRoom(_room);
                _navigationService.NavigateTo(typeof(ViewModels.RoomListViewModel).FullName);

            }

        }

        public RelayCommand SaveRoomCommand => new RelayCommand(new Action<object>(SaveCustomer), new Func<object, bool>(SaveRoomCanExecute));

        private bool SaveRoomCanExecute(object arg)
        {
            

            return true;
        }

        private void SaveCustomer(object obj)
        {
            _dataBaseService.SaveRoom(_room);
            _navigationService.NavigateTo(typeof(ViewModels.RoomListViewModel).FullName);
        }

        public Room Room { get => _room; set => SetProperty(ref _room, value); }







        public RoomEditViewModel(IDataBaseService dataBaseService, INavigationService navigationService, IDataStore dataStore)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            _room = dataStore.GetRoom();
            if (_room == null)
            {
                _room = new Room();
            }
        }

    }
}
