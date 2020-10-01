using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Model.Entity.Actions
{
    public class BookingActions
    {
        public BookingActions() {
        
        }
        public ObservableCollection<room> GetAllRooms()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<booking> auxList = new ObservableCollection<booking>();
            foreach(var booking in context.bookings)
            {
                auxList.Add(booking);
            }

            ObservableCollection<room> AvailableRoomsList = new ObservableCollection<room>();
            foreach (var room in context.rooms)
            {
               // if (auxList.Contains(room.id) == false)
                    AvailableRoomsList.Add(room);
            } 
            return AvailableRoomsList;
        }

        public ObservableCollection<booking> GetAllBookings()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<booking> auxList = new ObservableCollection<booking>();
            foreach (var booking in context.bookings)
            {
                // if (auxList.Contains(room.id) == false)
                if(booking.recordStatus=="Active")
                auxList.Add(booking);
            }
            return auxList;
        }

        public ObservableCollection<service> GetAllServices()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<service> auxList = new ObservableCollection<service>();
            foreach (var service in context.services)
            {
                // if (auxList.Contains(room.id) == false)
                auxList.Add(service);
            }
            return auxList;
        }

        public void SaveBooking(int id,DateTime selectedCheckIn,int Price, DateTime selectedCheckOut, room selectedRoom, string selectedRoomNumber, ObservableCollection<service> services,account cont)
        {
            if (selectedCheckIn >= selectedCheckOut)
            {
                MessageBox.Show("Selected Check-in invalid!");

            }
            else if (selectedRoom==null||selectedRoomNumber==""||selectedRoomNumber==null)
            {
                MessageBox.Show("Complete all fields!");

            }
            else {
                HotelEntities context = new HotelEntities();
                if (id == -1)
                    context.AddBooking(selectedCheckIn, selectedCheckOut, int.Parse(selectedRoomNumber), 1, Price, selectedRoom.id, cont.id);
                else
                    context.ModifyBooking(id, selectedCheckIn, selectedCheckOut, int.Parse(selectedRoomNumber), 1, Price, selectedRoom.id, cont.id);

                context.SaveChanges();
                foreach (var booking in context.bookings.ToList())
                {
                    if (booking.idUser == 1 && booking.checkIn == selectedCheckIn && booking.checkOut == selectedCheckOut)
                    {
                        foreach (var service in services)
                            context.AddServiceToBooking(service.id, booking.id);
                        context.SaveChanges();
                    }
                }
                MainViewModel.Instance.ActiveScreen = new BookingsViewModel(cont); }
        }

        public void DeleteBooking(int id,account _cont)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveBooking(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new BookingsViewModel(_cont);

        }

        internal offer GetAvailableOffer(DateTime selectedCheckIn, DateTime selectedCheckOut)
        {
            HotelEntities context = new HotelEntities();
            offer aux = new offer();
            bool foundOffer=false;
            foreach(var offer in context.offers.ToList())
            {
                if (offer.startDate <= selectedCheckIn && offer.dueDate >= selectedCheckOut && (selectedCheckOut - selectedCheckIn).Days == offer.nrBookedRooms)
                { aux = offer; foundOffer = true; }
            }
            if(foundOffer==false)
            {
                foreach (var offer in context.offers.ToList())
                {
                    if (offer.id==3)
                    { aux = offer; }
                }
            }
            return aux;
        }

        internal string Payment(booking booking)
        {
            if (booking.paid == "false")
                return "Visible";
            else
                return "Hidden";
        }

        internal void PayBooking(int id,account cont)
        {
            HotelEntities context = new HotelEntities();
            context.PayBooking(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new BookingsViewModel(cont);

        }
    }
}
