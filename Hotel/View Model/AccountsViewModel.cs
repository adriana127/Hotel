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
    public class AccountsViewModel : BaseViewModel
    {
        AccountActions actions;
        string _isAdmin;
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public AccountsViewModel()
        {
            actions = new AccountActions();
        }
        account _cont;
        public AccountsViewModel(account cont)
        {
            _cont = cont;
            actions = new AccountActions(); if (cont.userType == "Admin")
                IsAdmin = "Visible";
            else
                IsAdmin = "Hidden";
        }
        ObservableCollection<account> _accountList;

        public ObservableCollection<account> AccountList
        {
            get { _accountList = actions.GetAllAccounts(); return _accountList; }
            set
            {
                _accountList = value;
                OnPropertyChanged(nameof(AccountList));
            }
        }

        account _selectedAccount;

        public account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged(nameof(SelectedAccount));
                MainViewModel.Instance.ActiveScreen = new FormAccountViewModel(_selectedAccount,_cont);
            }
        }

        public ICommand NavigateAccountForm
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new FormAccountViewModel(_cont);
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
