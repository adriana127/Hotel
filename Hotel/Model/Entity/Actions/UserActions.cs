using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Model.Entity.Actions
{
    public class UserActions
    {
        public void LogIn(string name, string password)
        {
            HotelEntities context = new HotelEntities();

            var conturi = context.accounts.ToList();
            bool contExistent = false;
            foreach (var cont in conturi)
            {
                if (cont.email == name)
                {
                    if (cont.pass == password)
                    {

                        MessageBox.Show("Bun venit!");
                        MainViewModel.Instance.ActiveScreen = new BookingsViewModel(cont);
                    }
                    else
                    {
                        MessageBox.Show("Parola gresita!");

                    }
                    contExistent = true;
                }
            }
            if (contExistent == false)
            {
                MessageBox.Show("Cont inexistent!");
            }
        }
    
    }
}
