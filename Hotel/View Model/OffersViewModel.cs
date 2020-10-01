using Hotel.Command;
using Hotel.Model.Entity;
using Hotel.Model.Entity.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.View_Model
{
    public class OffersViewModel : BaseViewModel
    {
        OfferActions actions;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public OffersViewModel()
        {

        }
        account _cont;
        public OffersViewModel(account cont)
        {
            actions = new OfferActions();
            _cont = cont;
            actions = new OfferActions(); if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }

        ObservableCollection<offer> _offerList;

        public ObservableCollection<offer> OfferList
        {
            get { _offerList = actions.GetAllOffers(); return _offerList; }
            set
            {
                _offerList = value;
                OnPropertyChanged(nameof(OfferList));
            }
        }

        offer _selectedOffer;

        public offer SelectedOffer
        {
            get { return _selectedOffer; }
            set
            {
                _selectedOffer = value;
                OnPropertyChanged(nameof(SelectedOffer));
                MainViewModel.Instance.ActiveScreen = new FormOfferViewModel(_selectedOffer,_cont);
            }
        }

        public ICommand NavigateOfferForm
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new FormOfferViewModel(_cont);
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
