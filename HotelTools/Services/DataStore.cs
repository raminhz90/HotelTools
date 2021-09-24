using HotelTools.Core.Models.Enitities;
using HotelTools.Interfaces.Services;


namespace HotelTools.Services
{
    public class DataStore : IDataStore
    {
        private Customer _customer = null;
        private Room _room = null;

        public Customer GetCustomer() => _customer;

        public void setCustomer(Customer customer) => _customer = customer;

        public Room GetRoom()
        {
            return _room;
        }

        public void setRoom(Room room)
        {
            _room = room;
        }



    }
}
