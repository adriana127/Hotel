using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.View_Model
{
    class MainViewModel : BaseViewModel
    {

        BaseViewModel _activeScreen = new LoginViewModel();

        public MainViewModel()
        {
            Instance = this;
        }

        public BaseViewModel ActiveScreen
        {
            get => _activeScreen;
            set
            {
                _activeScreen = value;
                OnPropertyChanged(nameof(ActiveScreen));
            }
        }

        public static MainViewModel Instance { get; private set; }
    }
}
