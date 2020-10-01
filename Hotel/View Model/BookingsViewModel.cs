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
    class BookingsViewModel : BaseViewModel
    {
        BookingActions actions;
        account _cont;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public BookingsViewModel() {
            actions = new BookingActions();
        }

        public BookingsViewModel(account cont)
        {
            _cont = cont;
            actions = new BookingActions(); if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }

        ObservableCollection<booking> _bookingList;

        public ObservableCollection<booking> BookingList
        {
            get { _bookingList = actions.GetAllBookings(); return _bookingList; }
            set { _bookingList = value;
                OnPropertyChanged(nameof(BookingList));
            }
        }

        booking _selectedBooking;

        public booking SelectedBooking
        {
            get { return _selectedBooking; }
            set
            {
                _selectedBooking = value;
                OnPropertyChanged(nameof(SelectedBooking));
                MainViewModel.Instance.ActiveScreen = new FormBookingViewModel(_cont,_selectedBooking);
            }
        }

        public ICommand NavigateBookingForm
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new FormBookingViewModel(_cont);
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
