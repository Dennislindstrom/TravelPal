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
using TravelPal.Enums;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private readonly UserManager _userManager;
        public UserDetailsWindow()
        {
            InitializeComponent();
            cbSettingCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            cbSettingCountry.SelectedIndex = 0;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUserSettingsUserName.Text;
            string password = pbSettingsPassword.Password;
            Countries country = (Countries)cbSettingCountry.SelectedIndex;


            _userManager.addUser(username, password, country);

            MessageBox.Show("Settings has been changed", "Settings");
            Close();

            
        }
    }
}
