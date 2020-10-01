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
    public class ServicesViewModel : BaseViewModel
    {
        ServiceActions actions;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public ServicesViewModel()
        {

        }
        account _cont;
        public ServicesViewModel(account cont)
        {
            _cont = cont;
            actions = new ServiceActions();
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }

        string _serviceName;
        string _servicePrice;

        ObservableCollection<service> _serviceList;
        public ObservableCollection<service> ServiceList
        {
            get
            {
                _serviceList = actions.GetAllServices();
                return _serviceList;
            }
            set { _serviceList = value; OnPropertyChanged(nameof(ServiceList)); }
        }
        service _selectedService;
        public service SelectedService
        {
            get { return _selectedService; }
            set
            {
                _selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
                ServiceName = _selectedService.serviceName;
                ServicePrice = _selectedService.price.ToString();
            }
        }

        public string ServiceName { get => _serviceName; set { _serviceName = value; OnPropertyChanged(nameof(ServiceName)); } }
        public string ServicePrice { get => _servicePrice; set { _servicePrice = value; OnPropertyChanged(nameof(ServicePrice)); } }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(() => {
                    actions.Save(ServiceName,ServicePrice, _cont);

                });
            }
        }
        public ICommand Modify
        {
            get
            {
                return new RelayCommand(() => {
                    actions.Modify(SelectedService.id, ServiceName, ServicePrice, _cont);

                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() => {
                    actions.Delete(SelectedService.id);

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
