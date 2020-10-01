using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Model.Entity.Actions
{
    public class AccountActions
    {
        public AccountActions() { }
        public ObservableCollection<account> GetAllAccounts()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<account> auxList = new ObservableCollection<account>();
            foreach (var account in context.accounts.ToList())
            {
                // if (auxList.Contains(room.id) == false)
                if (account.recordStatus == "Active")
                    auxList.Add(account);
            }
            return auxList;
        }

        internal void SaveAccount(int id, string fullName, string email, string password, string userType, account cont)
        {
            if (fullName == "" || fullName == null || email == "" || email == null || password == "" || password == null || userType == "" || userType == null)
            {
                HotelEntities context = new HotelEntities();
                if (id == -1)
                {
                    context.AddAccount(email, fullName, password, userType);
                    context.SaveChanges();
                }
                else
                {
                    context.ModifyAccount(id, email, fullName, password, userType);
                    context.SaveChanges();
                }
                MainViewModel.Instance.ActiveScreen = new AccountsViewModel(cont);
            }
            else
                MessageBox.Show("Complete all fields!");

        }

        internal void DeleteAccount(int id,account _cont)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveAccount(id);
            context.SaveChanges();
        MainViewModel.Instance.ActiveScreen = new AccountsViewModel(_cont);
    }
    }
}
