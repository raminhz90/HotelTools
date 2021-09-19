using HotelTools.Core.Interfaces;
using HotelTools.Core.Models.Enitities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTools.Core.Services
{
    public class DataBaseService : IDataBaseService
    {
        readonly ApplicationDbContext _db;
        public DataBaseService()
        {
            _db = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetAllCustomers() => from c in _db.Customer select c;
        public IEnumerable<Room> GetAllRooms() => from c in _db.Room select c;
        public IEnumerable<Invoice> GetAllInvoices() => from i in _db.Invoices select i;

        public Task SaveCustomer(Customer customer)
        {
            if (_db.Customer.Contains(customer))
            {
                _db.Update(customer);
            }
            else
            {
                _db.Add(customer);
            }
            _db.SaveChanges();
            return Task.CompletedTask;
        }
        public Task SaveRoom(Room room)
        {
            if (_db.Room.Contains(room))
            {
                _db.Update(room);
            }
            else
            {
                _db.Add(room);
            }
            _db.SaveChanges();
            return Task.CompletedTask;
        }
        public Task SaveInvoice(Invoice invoice)
        {
            if (_db.Invoices.Contains(invoice))
            {
                _db.Update(invoice);
            }
            else
            {
                _db.Add(invoice);
            }
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task SaveCustomer(IEnumerable<Customer> customers)
        {
            Parallel.ForEach(customers, customer =>
            {
                if (_db.Customer.Contains(customer))
                {
                    _db.Update(customer);
                }
                else
                {
                    _db.Add(customer);
                }
            });

            _db.SaveChanges();
            return Task.CompletedTask;
        }
        public Task SaveRoom(IEnumerable<Room> rooms)
        {
            Parallel.ForEach(rooms, room =>
            {
                if (_db.Room.Contains(room))
                {
                    _db.Update(room);
                }
                else
                {
                    _db.Add(room);
                }
            });

            _db.SaveChanges();
            return Task.CompletedTask;
        }
        public Task SaveInvoice(IEnumerable<Invoice> invoices)
        {
            Parallel.ForEach(invoices, invoice =>
            {
                if (_db.Invoices.Contains(invoice))
                {
                    _db.Update(invoice);
                }
                else
                {
                    _db.Add(invoice);
                }
            });

            _db.SaveChanges();
            return Task.CompletedTask;
        }



        public Customer GetCustomerByID(int id) => (from c in _db.Customer where c.Id == id select c).FirstOrDefault();
        public Room GetRoomByID(int id) => (from c in _db.Room where c.Id == id select c).FirstOrDefault();
        public Invoice GetInvoiceByID(int id) => (from i in _db.Invoices where i.Id == id select i).FirstOrDefault();

        public Task DeleteCustomer(Customer customer)
        {
            _db.Customer.Remove(customer);
            _db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
