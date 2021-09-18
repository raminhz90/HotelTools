using HotelTools.Core.Models.Enitities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelTools.Core.Interfaces
{
    public interface IDataBaseService
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Room> GetAllRooms();
        Customer GetCustomerByID(int id);
        Task SaveCustomer(Customer customer);
        Task SaveCustomer(IEnumerable<Customer> customer);
        Invoice GetInvoiceByID(int id);
        Task SaveInvoice(Invoice invoice);
        Task SaveInvoice(IEnumerable<Invoice> invoice);
        Room GetRoomByID(int id);
        Task SaveRoom(Room room);
        Task SaveRoom(IEnumerable<Room> room);
    }
}