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
    public class RoomsViewModel : BaseViewModel
    {

        RoomActions actions;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public RoomsViewModel()
        {

        }
        account _cont;
        public RoomsViewModel(account cont)
        {
        _cont=cont;
            actions = new RoomActions(); if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        ObservableCollection<RoomDisplay> _roomsList;
        RoomDisplay _selectedRoom;
        public ObservableCollection<RoomDisplay> RoomsList { get { _roomsList = actions.GetRooms(); return _roomsList; } set { _roomsList = value; OnPropertyChanged(nameof(RoomsList)); } }
        public RoomDisplay SelectedRoom { get { return _selectedRoom; } 
            set { 
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
                MainViewModel.Instance.ActiveScreen = new FormRoomViewModel(_cont,actions.GetRoomById(_selectedRoom.Id)); 
            } }

        public ICommand NavigateRoomForm
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new FormRoomViewModel(_cont);
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
