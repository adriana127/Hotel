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
    public class FormRoomViewModel : BaseViewModel
    {
        RoomActions actions;
        room _room;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public FormRoomViewModel() {
            actions = new RoomActions();
            Visible = "Hidden";
        }
        account _cont;

        public FormRoomViewModel(account cont)
        {
            _cont = cont;
            actions = new RoomActions(); if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
            Visible = "Hidden";
        }
        public FormRoomViewModel(account cont,room room)
        {
            _cont = cont;

            _room = room;
            Capacity = room.capacity.ToString();
            Price = room.price.ToString();
            NumberOfRooms = room.numberofrooms.ToString();
            Visible = "Visible";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";

            actions = new RoomActions();
        }
        string _visibility;
        ObservableCollection<roomPhoto> _photoList;
        ObservableCollection<feature> _featureList;
        string _capacity;
        string _price;
        string _numberOfRooms;
        roomPhoto _selectedPhoto;
        feature _selectedFeature;

        public ObservableCollection<roomPhoto> PhotoList
        {
            get
            {
                if(_room!=null)
                _photoList = actions.GetPhotos(_room.id);
                return _photoList;
            }
            set
            {
                _photoList = value;
                OnPropertyChanged(nameof(PhotoList));
            }

        }
        public ObservableCollection<feature> FeatureList
        {
            get
            {
                _featureList = actions.GetFeatures();
                return _featureList;
            }
            set
            {
                _featureList = value;
                OnPropertyChanged(nameof(FeatureList));
            }

        }
        public ICommand AddPhoto
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.AddPhoto(_room.id);
                    PhotoList = actions.GetPhotos(_room.id);
                });
            }
        }
        public roomPhoto SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                _selectedPhoto = value;
                OnPropertyChanged(nameof(SelectedPhoto));

            }
        }
        public feature SelectedFeature
        {
            get { return _selectedFeature; }
            set
            {
                _selectedFeature = value;
                OnPropertyChanged(nameof(SelectedFeature));

            }
        }
        public string Capacity
        {
            get { return _capacity; }
            set
            {
                _capacity = value;
                OnPropertyChanged(nameof(Capacity));

            }
        }
        public string Visible
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visible));

            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));

            }
        }
        public string NumberOfRooms
        {
            get { return _numberOfRooms; }
            set
            {
                _numberOfRooms = value;
                OnPropertyChanged(nameof(NumberOfRooms));

            }
        }
        public ICommand DeletePhoto
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.DeletePhoto(SelectedPhoto.id);
                    PhotoList = actions.GetPhotos(_room.id);
                });
            }
        }
        public ICommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(_room!=null)
                    actions.Save(_room.id, Price, Capacity, NumberOfRooms, SelectedFeature,_cont);
                    else
                        actions.Save(-1, Price, Capacity, NumberOfRooms, SelectedFeature,_cont);


                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() =>
                {
                        actions.Delete(_room.id, _cont);
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
