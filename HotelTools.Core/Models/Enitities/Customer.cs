using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTools.Core.Models.Enitities
{
    [Table("Customers", Schema = "dbo")]
    public class Customer : EntityBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _nationalID;
        private string _phoneNumber;
        private string _address;
        private string _comment;
        private string _sex;
        private DateTime _birthday;
        private DateTime _lastVisit;

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_firstName))]
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value, true); }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_lastName))]
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_email))]
        public string Email { get => _email; set => SetProperty(ref _email, value, true); }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_nationalID))]
        public string NationalID { get => _nationalID; set => SetProperty(ref _nationalID, value, true); }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_phoneNumber))]
        public string PhoneNumber { get => _phoneNumber; set => SetProperty(ref _phoneNumber, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_address))]
        public string Address { get => _address; set => SetProperty(ref _address, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_comment))]
        public string Comment { get => _comment; set => SetProperty(ref _comment, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_birthday))]
        public DateTime Birthday { get => _birthday; set => SetProperty(ref _birthday, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_lastVisit))]
        public DateTime LastVisit { get => _lastVisit; set => SetProperty(ref _lastVisit, value, true); }

        [StringLength(50)]
        [BackingField(nameof(_sex))]
        public string Sex { get => _sex; set => _sex = value; }
    }
}
