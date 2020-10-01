using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model.Entity.Actions
{
    public class ServiceActions
    {
        public ServiceActions() { }
        public ObservableCollection<service> GetAllServices()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<service> auxList = new ObservableCollection<service>();
            foreach (var service in context.services.ToList())
            {
                if (service.recordStatus == "Active")
                {

                    auxList.Add(service);

                }
            }
            return auxList;
        }
        public void Save(string serviceName,string price,account cont)
        {
            HotelEntities context = new HotelEntities();
            context.AddService(serviceName, int.Parse(price));
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new ServicesViewModel(cont);
        }

        public void Modify(int id, string featureName, string price,account cont)
        {
            HotelEntities context = new HotelEntities();
            context.ModifyService(id, featureName, int.Parse(price));
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new ServicesViewModel(cont);
        }
        public void Delete(int id)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveServices(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new ServicesViewModel();
        }
    }
}
