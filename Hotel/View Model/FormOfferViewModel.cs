using Hotel.Command;
using Hotel.Model.Entity;
using Hotel.Model.Entity.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.View_Model
{
    public class FormOfferViewModel : BaseViewModel
    {

        OfferActions actions;
        offer _offer;
        string _visible;
        account _cont;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public FormOfferViewModel(offer offer, account cont)
        {
        _cont=cont;
            _offer = offer;
            OfferName = offer.offerName;
            Price = offer.newPrice.ToString();
            NumberOfBookedRooms = offer.nrBookedRooms.ToString();
            StartDate = DateTime.Parse(offer.startDate.ToString());
            DueDate = DateTime.Parse(offer.dueDate.ToString());

            actions = new OfferActions();
            Visible = "Visible";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";


        }
        public FormOfferViewModel(account cont)
        {
            _cont=cont;
            actions = new OfferActions();
           StartDate= System.DateTime.Today; 
            DueDate= System.DateTime.Today;
            Visible = "Hidden";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        string _offerName;
        string _email;
        string _nrBookedRooms;
        string _price;
        DateTime _startDate;
        DateTime _dueDate;

        public string Visible
        {
            get => _visible;
            set { _visible = value; OnPropertyChanged(nameof(Visible)); }
        }
        public string OfferName
        {
            get => _offerName;
            set { _offerName = value; OnPropertyChanged(nameof(OfferName)); }
        }

        public string Price
        {
            get => _price; set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string NumberOfBookedRooms
        {
            get => _nrBookedRooms;
            set { _nrBookedRooms = value; OnPropertyChanged(nameof(NumberOfBookedRooms)); }
        }
        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }
        public DateTime DueDate
        {
            get => _dueDate;
            set { _dueDate = value; OnPropertyChanged(nameof(DueDate)); }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(() => {
                    if (_offer == null)
                        actions.SaveOffer(-1, OfferName, NumberOfBookedRooms, Price, StartDate, DueDate,_cont);
                    else
                        actions.SaveOffer(_offer.id, OfferName, NumberOfBookedRooms, Price ,StartDate, DueDate,_cont);


                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() => {

                    actions.DeleteOffer(_offer.id, _cont);

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
