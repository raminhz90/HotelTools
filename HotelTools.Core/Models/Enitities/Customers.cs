using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTools.Core.Models.Enitities
{
    [Table("Customers", Schema = "dbo")]
    internal class Customers : EntityBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _nationalID;
        private string _phoneNumber;
        private string _address;
        private string _comment;
        private DateTime _birthday;
        private DateTime _lastVisit;

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_firstName))]
        public string FirstName { get => _firstName; set => _firstName = value; }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_lastName))]
        public string LastName { get => _lastName; set => _lastName = value; }

        [StringLength(50)]
        [BackingField(nameof(_email))]
        public string Email { get => _email; set => _email = value; }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_nationalID))]
        public string NationalID { get => _nationalID; set => _nationalID = value; }

        [StringLength(50)]
        [Required]
        [BackingField(nameof(_phoneNumber))]
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        [StringLength(50)]
        [BackingField(nameof(_address))]
        public string Address { get => _address; set => _address = value; }

        [StringLength(50)]
        [BackingField(nameof(_comment))]
        public string Comment { get => _comment; set => _comment = value; }

        [StringLength(50)]
        [BackingField(nameof(_birthday))]
        public DateTime Birthday { get => _birthday; set => _birthday = value; }

        [StringLength(50)]
        [BackingField(nameof(_lastName))]
        public DateTime LastVisit { get => _lastVisit; set => _lastVisit = value; }
    }
}
