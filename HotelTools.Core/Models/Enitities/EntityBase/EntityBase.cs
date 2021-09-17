using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelTools.Core.Models.Enitities
{
    public abstract class EntityBase : ObservableValidator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        [Timestamp]
        public byte[]? Timestamp {  get; set; }

        [NotMapped]
        public bool Ischanged {  get; set; }



    }
}
