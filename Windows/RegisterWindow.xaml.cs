using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.Serialization;
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
using TravelPal.Enums;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserManager _userManager;
        
        // Öppna window för att kunna registrera sig och displaya land
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            cbCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            cbCountries.SelectedIndex = 0;
        }

        // Registreringsknapp för att kunna registrera user 
        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            string username = tbRegisterUserName.Text;
            string password = pbRegisterPassword.Password;
            Countries country = (Countries)cbCountries.SelectedIndex;


            _userManager.addUser(username, password, country);

            MessageBox.Show("Your user has been added", "hest");
            Close();

        }
    }
}

