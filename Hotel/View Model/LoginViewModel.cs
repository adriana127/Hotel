using Hotel.Command;
using Hotel.Model.Entity.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.View_Model
{
   public class LoginViewModel : BaseViewModel
    {
        UserActions actions;
        public LoginViewModel()
        {
            actions = new UserActions();
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public ICommand LogIn
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.LogIn(UserName, UserPassword);

                });
            }
        }
        public ICommand SignUp
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new SignUpViewModel();

                });
            }
        }
    }
}
