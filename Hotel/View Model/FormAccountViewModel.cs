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
    public class FormAccountViewModel : BaseViewModel
    {
        ObservableCollection<string> _userTypes;
        AccountActions actions;
        account _account;
        string _visible;
        account _cont;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public FormAccountViewModel(account account,account cont)
        {
            _cont = cont;
            _account = account;
            FullName = account.fullname;
            Email = account.email;
            Password = account.pass;
            UserType = account.userType;
            //selec
            actions = new AccountActions();
            UserTypes = new ObservableCollection<string>();
            UserTypes.Add("Client");
            UserTypes.Add("Admin");
            UserTypes.Add("Hotel employee");
            Visible = "Visible";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";

        }
        public FormAccountViewModel()
        {
            actions = new AccountActions();
            UserTypes = new ObservableCollection<string>();
            UserTypes.Add("Client");
            UserTypes.Add("Admin");
            UserTypes.Add("Hotel employee");
            Visible = "Hidden";
        }

        public FormAccountViewModel(account cont)
        {
            _cont = cont;
            actions = new AccountActions();
            UserTypes = new ObservableCollection<string>();
            UserTypes.Add("Client");
            UserTypes.Add("Admin");
            UserTypes.Add("Hotel employee");
            Visible = "Hidden";
            if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }

        string _fullName;
        string _email;
        string _password;
        string _userType;

        public string Visible
        {
            get => _visible;
            set { _visible = value; OnPropertyChanged(nameof(Visible)); }
        }
        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }
        
        public string UserType
        {
            get => _userType; set { _userType = value; 
                OnPropertyChanged(nameof(UserType)); }
        }
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string Email
        {
            get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public ICommand Save
        {
            get
            {
                return new RelayCommand(() => {
                    if (FullName == "" || Email == "" || Password == "" || UserType == "")
                        MessageBox.Show("Complete all fields!");
                    else
                    {
                        if (_account == null)
                            actions.SaveAccount(-1, FullName, Email, Password, UserType, _cont);
                        else
                            actions.SaveAccount(_account.id, FullName, Email, Password, UserType, _cont);
                    }

                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(() => {

                    actions.DeleteAccount(_account.id, _cont);

                });
            }
        }

        public ObservableCollection<string> UserTypes { get => _userTypes; set { _userTypes = value;
                
                OnPropertyChanged(nameof(UserTypes)); } }

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
