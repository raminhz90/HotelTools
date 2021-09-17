using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTools.Core.Models.Enitities
{
    [Table("Invoices", Schema = "dbo")]
    public class Invoice : EntityBase
    {
        private DateTime _checkOutDate;
        private DateTime _checkInDate;
        private DateTime _dateIssued;
        private int _numberofguests;
        private decimal _discount = 0;
        private decimal _reservationPay = 0;
        private decimal _miscCosts = 0;
        private decimal _totalPrice;
        private decimal _remaining = 0;
        private bool _isCustomPrice = false;
        private decimal _customPrice = 0;
        private List<InvoiceRoom> _occupiedRooms;
        private int _customerId;
        private Customer _invoiceCustomer;


        [Required]
        [BackingField(nameof(_checkOutDate))]
        public DateTime CheckOutDate { get => _checkOutDate; set => SetProperty(ref _checkOutDate, value, true); }


        [Required]
        [BackingField(nameof(_checkInDate))]
        public DateTime CheckInDate { get => _checkInDate; set =>SetProperty(ref _checkInDate , value,true); }


        [Required]
        [BackingField(nameof(_dateIssued))]
        public DateTime DateIssued { get => _dateIssued; set => SetProperty(ref _dateIssued, value, true); }


        [Required]
        [BackingField(nameof(_numberofguests))]
        public int Numberofguests { get => _numberofguests; set => SetProperty(ref _numberofguests, value, true); }


        [Required]
        [BackingField(nameof(_discount))]
        public decimal Discount { get => _discount; set => SetProperty(ref _discount, value, true); }

        [Required]
        [BackingField(nameof(_reservationPay))]
        public decimal ReservationPay { get => _reservationPay; set => SetProperty(ref _reservationPay, value, true); }

        [Required]
        [BackingField(nameof(_miscCosts))]
        public decimal MiscCosts { get => _miscCosts; set => SetProperty(ref _miscCosts, value, true); }

        [Required]
        [BackingField(nameof(_totalPrice))]
        public decimal TotalPrice { get => _totalPrice; set => SetProperty(ref _totalPrice, value, true); }

        [Required]
        [BackingField(nameof(_remaining))]
        public decimal Remaining { get => _remaining; set => SetProperty(ref _remaining, value, true); }

        [Required]
        [BackingField(nameof(_isCustomPrice))]
        public bool IsCustomPrice { get => _isCustomPrice; set => SetProperty(ref _isCustomPrice, value, true); }

        [Required]
        [BackingField(nameof(_occupiedRooms))]
        [InverseProperty(nameof(InvoiceRoom.Invoice))]
        public List<InvoiceRoom> OccupiedRooms { get => _occupiedRooms; set => SetProperty(ref _occupiedRooms, value, true); }


        [BackingField(nameof(_customPrice))]
        public decimal CustomPrice { get => _customPrice; set => SetProperty(ref _customPrice, value, true); }


        [BackingField(nameof(_customerId))]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get => _customerId; set => SetProperty(ref _customerId, value, true); }


        [BackingField(nameof(_invoiceCustomer))]
        public Customer InvoiceCustomer { get => _invoiceCustomer; set => SetProperty(ref _invoiceCustomer, value, true); }
    }
}
