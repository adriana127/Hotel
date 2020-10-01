using Hotel.Command;
using Hotel.Model.Entity;
using Hotel.Model.Entity.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.View_Model
{
    class FeaturesViewModel : BaseViewModel
    {
        FeatureActions actions;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public FeaturesViewModel()
        {
            actions = new FeatureActions();
        }
        account _cont;
        public FeaturesViewModel(account cont)
        {
            _cont = cont;
            actions = new FeatureActions();
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        string _featureName;
        ObservableCollection<feature> _featureList;
        public ObservableCollection<feature> FeatureList { get { _featureList = actions.GetAllFeatures(); 
                return _featureList; } 
            set { _featureList = value; OnPropertyChanged(nameof(FeatureList)); } }
        feature _selectedFeature;
        public feature SelectedFeature
        {
            get { return _selectedFeature; }
            set
            {
                _selectedFeature = value;
                OnPropertyChanged(nameof(SelectedFeature));
                FeatureName = _selectedFeature.featureName;
            }
        }

        public string FeatureName { get => _featureName; set { _featureName = value; OnPropertyChanged(nameof(FeatureName)); } }
   
    public ICommand Save
        {
            get { return new RelayCommand(() => {
                if (FeatureName == null || FeatureName == "")
                    MessageBox.Show("Complete name field!");
                else
                    actions.Save(FeatureName);
            
            }); }
        }
        public ICommand Modify
        {
            get
            {
                return new RelayCommand(() => {
                    if (FeatureName == null || FeatureName == "")
                        MessageBox.Show("Complete name field!");
                    else

                        actions.Modify(SelectedFeature.id,FeatureName);

                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() => {
                    actions.Delete(SelectedFeature.id);

                });
            }
        }

        public ICommand ChangeScreenToBookings
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new BookingsViewModel(_cont);
                });
            }
        }
        public ICommand ChangeScreenToOffers
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new OffersViewModel(_cont);
                });
            }
        }
        public ICommand ChangeScreenToRooms
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new RoomsViewModel(_cont);
                });
            }
        }
        public ICommand ChangeScreenToServices
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new ServicesViewModel(_cont);
                });
            }
        }
        public ICommand ChangeScreenToFeatures
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new FeaturesViewModel(_cont);
                });
            }
        }
        public ICommand ChangeScreenToAccounts
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new AccountsViewModel(_cont);
                });
            }
        }
    }
}
