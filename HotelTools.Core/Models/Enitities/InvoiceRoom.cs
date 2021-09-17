using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTools.Core.Models.Enitities
{
    [Table("InvoiceRoom", Schema = "dbo")]
    public class InvoiceRoom : EntityBase
    {

        private int _invoiceId;
        private Invoice _invoice;
        private int _roomId;
        private Room _room;

        [BackingField(nameof(_invoiceId))]
        public int InvoiceId { get => _invoiceId; set => _invoiceId = value; }
        [BackingField(nameof(_invoice))]
        public virtual Invoice Invoice { get => _invoice; set => _invoice = value; }
        [BackingField(nameof(_roomId))]
        public int RoomId { get => _roomId; set => _roomId = value; }
        [BackingField(nameof(_room))]
        public virtual Room Room { get => _room; set => _room = value; }
    }
}