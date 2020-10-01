using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model.Entity
{
    public class RoomDisplay
    {
        string _capacity;
        string _price;
        string _photoPath;
        int _id;

        public RoomDisplay(string capacity, string price, string photoPath, int id)
        {
            _capacity = capacity;
            _price = price;
            _photoPath = photoPath;
            _id = id;
        }

        public string Capacity { get => _capacity; set => _capacity = value; }
        public string Price { get => _price; set => _price = value; }
        public string PhotoPath { get => _photoPath; set => _photoPath = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
