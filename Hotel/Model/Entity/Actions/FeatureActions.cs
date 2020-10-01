using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model.Entity.Actions
{
    public class FeatureActions
    {
        public FeatureActions() { }
        public ObservableCollection<feature> GetAllFeatures()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<feature> auxList = new ObservableCollection<feature>();
            foreach (var feature in context.features.ToList())
            {
                if (feature.recordStatus == "Active")
                {

                    auxList.Add(feature);

                }
            }
            return auxList;
        }
        public void Save(string featureName)
        {
            HotelEntities context = new HotelEntities();
            context.AddFeature(featureName);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new FeaturesViewModel();
        }

        public void Modify(int id, string featureName)
        {
            HotelEntities context = new HotelEntities();
            context.ModifyFeature(id,featureName);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new FeaturesViewModel();
        }
        public void Delete(int id)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveFeatures(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new FeaturesViewModel();
        }
    }
}
