using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Classes;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for TravelWindow.xaml
    /// </summary>
    public partial class TravelWindow : Window
    {
       
        private readonly UserManager _userManager;
        private readonly User _user;

        public TravelWindow()
        {
            InitializeComponent();
        }

        public TravelWindow(UserManager userManager, User user)
        {
            InitializeComponent();
            _userManager = userManager;
            _user = user;
        }
    }
}
