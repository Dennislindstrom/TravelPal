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

        public readonly User _user;
        public TravelWindow()
        {
            InitializeComponent();
        }



        public TravelWindow(UserManager userManager, User user)
        {
            InitializeComponent();
            _userManager = userManager;
            _user = user;

            lblDisplayUser.Content = _user.Username;
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            Window addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            Window userDetailswindow = new UserDetailsWindow();
            userDetailswindow.Show();
            

        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Window mainwindow = new MainWindow();
            mainwindow.Close();
            MessageBox.Show($"Bye, {_user.Username}. please give G as slutbetyg");


        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Window infoWindow = new InfoWindow();
            infoWindow.Show();

            //MessageBox.Show($"Hello {_user.Username} this is an app, please give G as slutbetyg");
        }


    }
}
