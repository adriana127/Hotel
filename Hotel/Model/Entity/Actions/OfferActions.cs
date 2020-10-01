using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model.Entity.Actions
{
   public class OfferActions
    {
        public OfferActions() { }

        public  ObservableCollection<offer> GetAllOffers()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<offer> auxList = new ObservableCollection<offer>();
            foreach (var offer in context.offers.ToList())
            {

                if (offer.recordStatus == "Active")
                    auxList.Add(offer);
            }
            return auxList;
        }

        internal void SaveOffer(int id, string name, string numberOfBookedRooms, string price, DateTime startDate, DateTime dueDate,account cont)
        {
            HotelEntities context = new HotelEntities();
            if (id == -1)
            {
                context.AddOffer(name, int.Parse(numberOfBookedRooms), int.Parse(price), startDate, dueDate);
                context.SaveChanges();
            }
            else
            {
                context.ModifyOffer(id, name, int.Parse(numberOfBookedRooms), int.Parse(price), startDate, dueDate);
                context.SaveChanges();
            }
            MainViewModel.Instance.ActiveScreen = new OffersViewModel(cont);
        }

        internal void DeleteOffer(int id, account cont)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveOffers(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new OffersViewModel(cont);
        }
    }
}
