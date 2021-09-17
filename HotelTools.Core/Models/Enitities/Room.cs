using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTools.Core.Models.Enitities
{
    [Table("Rooms", Schema = "dbo")]
    public class Room : EntityBase
    {
        private int _roomNumber;
        private int? _roomSurface;
        private int? _bedrooms;
        private int? _beds;
        private string _comments;
        private int? _complexNumber;
        private decimal _roomPrice;
        private int _floor;


        [Required]
        [BackingField(nameof(_floor))]
        public int Floor { get => _floor; set => SetProperty(ref _floor, value, true); }

        [Required]
        [BackingField(nameof(_roomPrice))]
        public decimal RoomPrice { get => _roomPrice; set =>SetProperty(ref _roomPrice , value,true); }

        [Required]
        [BackingField(nameof(_complexNumber))]
        public int? ComplexNumber { get => _complexNumber; set => SetProperty(ref _complexNumber, value, true); }

        [BackingField(nameof(_comments))]
        public string Comments { get => _comments; set => SetProperty(ref _comments, value, true); }

        [BackingField(nameof(_beds))]
        public int? Beds { get => _beds; set => SetProperty(ref _beds, value, true); }

        [BackingField(nameof(_bedrooms))]
        public int? Bedrooms { get => _bedrooms; set => SetProperty(ref _bedrooms, value, true); }

        [BackingField(nameof(_roomSurface))]
        public int? RoomSurface { get => _roomSurface; set => SetProperty(ref _roomSurface, value, true); }

        [BackingField(nameof(_roomNumber))]
        public int RoomNumber { get => _roomNumber; set => SetProperty(ref _roomNumber, value, true); }
    }
}
