using HandyControl.Tools.Command;
using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelTools.ViewModels
{
    public class RoomListViewModel : ObservableObject
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly INavigationService _navigationService;
        private readonly IDataStore _dataStore;
        private ObservableCollection<Room> _roomDatagrid = new ObservableCollection<Room>();
        private List<Room> _rooms = new List<Room>();
        private string _searchQuery = string.Empty;

        public Room SelectedRoom { get; set; }

        public RoomListViewModel(IDataBaseService dataBaseService, INavigationService navigationService, IDataStore dataStore)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            _dataStore = dataStore;
            _rooms = dataBaseService.GetAllRooms().ToList();


            RoomDatagrid = new ObservableCollection<Room>(_rooms);
        }

        public ObservableCollection<Room> RoomDatagrid { get => _roomDatagrid; set => SetProperty(ref _roomDatagrid, value); }
        public RelayCommand AddNewRoomCommand => new RelayCommand(new Action<object>(AddRoom));
        public RelayCommand EditRoomCommand => new RelayCommand(new Action<object>(EditRoom));
        public RelayCommand DeleteRoomCommand => new RelayCommand(new Action<object>(DeleteRoom), new Func<object, bool>(DeleteRoomCanExecute));

        private bool DeleteRoomCanExecute(object arg)
        {
            if (SelectedRoom != null)
            {
                return true;
            }
            else return false;
        }

        private void DeleteRoom(object obj)
        {
            _dataBaseService.DeleteRoom(SelectedRoom);
        }

        private void EditRoom(object obj)
        {
            _dataStore.setRoom(SelectedRoom);
            _navigationService.NavigateTo(typeof(ViewModels.RoomEditViewModel).FullName);
        }

        private void AddRoom(object obj)
        {
            _dataStore.setRoom(new Room());
            _navigationService.NavigateTo(typeof(ViewModels.RoomEditViewModel).FullName);
        }
    }
}
