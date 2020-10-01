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
    public class FormBookingViewModel : BaseViewModel
    {
        BookingActions actions;
        booking _booking;
        account _cont;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }
        public FormBookingViewModel(account cont, booking booking)
        {
            _cont = cont;
            actions = new BookingActions();
            SelectedServices = new ObservableCollection<service>();

            _booking = booking;
            SelectedCheckIn = DateTime.Parse(booking.checkIn.ToString());
            SelectedCheckOut = DateTime.Parse(booking.checkOut.ToString());
            SelectedRoomNumber = booking.numberBookedRooms.ToString();
            SelectedRoom = booking.room;
            //selec
            actions = new BookingActions();
            NrOfRooms = new ObservableCollection<string>();
            NrOfRooms.Add("1");
            NrOfRooms.Add("2");
            NrOfRooms.Add("3");
            NrOfRooms.Add("4");
            NrOfRooms.Add("5");
            NrOfRooms.Add("6");
            NrOfRooms.Add("7");
            NrOfRooms.Add("8");
            NrOfRooms.Add("9");
            NrOfRooms.Add("10");
            if (PaymentVisible == "Hidden")
                ModifyVisible = "Hidden";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        public FormBookingViewModel() { }
        public FormBookingViewModel(account cont)
        {
            _cont = cont;
            actions = new BookingActions();
            NrOfRooms = new ObservableCollection<string>();
            NrOfRooms.Add("1");
            NrOfRooms.Add("2");
            NrOfRooms.Add("3");
            NrOfRooms.Add("4");
            NrOfRooms.Add("5");
            NrOfRooms.Add("6");
            NrOfRooms.Add("7");
            NrOfRooms.Add("8");
            NrOfRooms.Add("9");
            NrOfRooms.Add("10");
            SelectedCheckIn = System.DateTime.Today;
            SelectedCheckOut = System.DateTime.Today;
            SelectedServices = new ObservableCollection<service>();
            ModifyVisible = "Visible";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        DateTime _selectedCheckIn;
        DateTime _selectedCheckOut;
        ObservableCollection<string> _nrOfRooms;
        ObservableCollection<room> _availableRooms;
        offer _offer;
        string _price;
        public ObservableCollection<room> AvailableRooms
        {
            get
            {
                _availableRooms = actions.GetAllRooms();

                return _availableRooms;
            }
            set { _availableRooms = value; OnPropertyChanged(nameof(AvailableRooms)); }
        }
        ObservableCollection<service> _services;

        public ObservableCollection<service> ServicesList
        {
            get
            {
                _services = actions.GetAllServices();

                return _services;
            }
            set { _services = value; OnPropertyChanged(nameof(ServicesList)); }
        }
        room _selectedRoom;
        public DateTime SelectedCheckIn { get => _selectedCheckIn;
            set { _selectedCheckIn = value; OnPropertyChanged(nameof(SelectedCheckIn)); } }
        public DateTime SelectedCheckOut { get => _selectedCheckOut; set {_selectedCheckOut = value; OnPropertyChanged(nameof(SelectedCheckOut));
                if (SelectedCheckIn != SelectedCheckOut && SelectedRoomNumber != null && SelectedRoom != null)
                {
                    int aux = 0;
                    if (Offer.id == 3)
                        aux = (SelectedCheckOut - SelectedCheckIn).Days * int.Parse(_selectedRoomNumber) * int.Parse(SelectedRoom.price.ToString());
                    else
                        aux = int.Parse(Offer.newPrice.ToString()) * int.Parse(_selectedRoomNumber);
                    if (SelectedServices.Count() != 0)

                    {
                        foreach (var service in SelectedServices)
                            aux += int.Parse(service.price.ToString());
                    }
                    Price = aux.ToString();
                    
                }
            } 
    }
        string _selectedRoomNumber;
        public room SelectedRoom { get => _selectedRoom; set { _selectedRoom = value; OnPropertyChanged(nameof(SelectedRoom));

                if (SelectedCheckIn != SelectedCheckOut && SelectedRoomNumber != null && SelectedRoom != null)
                {
                    int aux = 0;
                    if (Offer.id == 3)
                        aux = (SelectedCheckOut - SelectedCheckIn).Days * int.Parse(_selectedRoomNumber) * int.Parse(SelectedRoom.price.ToString());
                    else
                        aux = int.Parse(Offer.newPrice.ToString()) * int.Parse(_selectedRoomNumber);

                    if (SelectedServices.Count() != 0)

                    {
                        foreach (var service in SelectedServices)
                            aux += int.Parse(service.price.ToString());
                    }
                    Price = aux.ToString();
                }
            } }



        ObservableCollection<service> _selectedServices;
        public ObservableCollection<service> SelectedServices { 
            get => _selectedServices; 
            set {
                _selectedServices = value; 
                OnPropertyChanged(nameof(SelectedServices));
            } }

        string _paymentVisible = "Hidden";
        service _selectedService;
        public service SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
                if (SelectedServices.Contains(_selectedService) == false)
                    SelectedServices.Add(SelectedService);
                else
                    SelectedServices.Remove(SelectedService);
                if (SelectedCheckIn != SelectedCheckOut && SelectedRoomNumber != null && SelectedRoom != null)
                {
                    int aux = 0;
                    if (Offer.id == 3)
                        aux = (SelectedCheckOut - SelectedCheckIn).Days * int.Parse(_selectedRoomNumber) * int.Parse(SelectedRoom.price.ToString());
                    else
                        aux = int.Parse(Offer.newPrice.ToString()) * int.Parse(_selectedRoomNumber);

                    if (SelectedServices.Count() != 0)

                    {
                        foreach (var service in SelectedServices)
                            aux += int.Parse(service.price.ToString());
                    }
                    Price = aux.ToString();
                }
            }
        }


        public string SelectedRoomNumber { get => _selectedRoomNumber;
            set { _selectedRoomNumber = value;
                OnPropertyChanged(nameof(SelectedRoomNumber));

                if (SelectedCheckIn != SelectedCheckOut && SelectedRoomNumber != null&&SelectedRoom!=null)
                {
                    int aux = 0;
                    if (Offer.id==3)
                        aux = (SelectedCheckOut - SelectedCheckIn).Days * int.Parse(_selectedRoomNumber) * int.Parse(SelectedRoom.price.ToString());
                    else
                        aux = int.Parse(Offer.newPrice.ToString()) * int.Parse(_selectedRoomNumber);

                    if (SelectedServices.Count() != 0)

                    {
                        foreach (var service in SelectedServices)
                            aux += int.Parse(service.price.ToString());
                }
                    Price = aux.ToString();
                }
            } }

        public ObservableCollection<string> NrOfRooms { get => _nrOfRooms; set { _nrOfRooms = value; OnPropertyChanged(nameof(NrOfRooms));

            
            } }


        public ICommand SaveBooking
        {
            get { return new RelayCommand(() => {
            if (_booking != null)
                    if (SelectedRoom == null || SelectedRoomNumber == null || SelectedRoomNumber == "")
                    {
                        MessageBox.Show("Complete all fields!");

                    }
                    else actions.SaveBooking(_booking.id, SelectedCheckIn, int.Parse(Price), SelectedCheckOut, SelectedRoom, SelectedRoomNumber, SelectedServices, _cont);
            else
                if (SelectedRoom == null || SelectedRoomNumber == null||SelectedRoomNumber=="")
                {
                MessageBox.Show("Complete all fields!");

                }
                    else actions.SaveBooking(-1, SelectedCheckIn, int.Parse(Price), SelectedCheckOut, SelectedRoom, SelectedRoomNumber, SelectedServices,_cont);

            }); }
        }
        public ICommand PayBooking
        {
            get
            {
                return new RelayCommand(() => {
                   
                        actions.PayBooking(_booking.id,_cont);

                });
            }
        }
        public ICommand DeleteBooking
        {
            get
            {
                return new RelayCommand(() => {

                    actions.DeleteBooking(_booking.id,_cont);

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

        public string Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }

        public offer Offer { get {
                _offer = actions.GetAvailableOffer(SelectedCheckIn, SelectedCheckOut);
                return _offer; } set { _offer = value; OnPropertyChanged(nameof(Offer)); } }

        public string PaymentVisible { get {

                if (_booking == null)
                    _paymentVisible = "Hidden";
                else _paymentVisible=actions.Payment(_booking);
                return _paymentVisible;
            } set { _paymentVisible = value; OnPropertyChanged(nameof(PaymentVisible)); } }

        string _modifyVisible;
        public string ModifyVisible
        {
            get
            {

                return _modifyVisible;
            }
            set { _modifyVisible = value; OnPropertyChanged(nameof(ModifyVisible)); }
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
