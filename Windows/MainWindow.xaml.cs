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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager _userManager = new();
        

        public MainWindow()
        {
            InitializeComponent();
        }
        
        //Knapp som öppnar registerWindow
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new RegisterWindow(_userManager);
            registerWindow.Show();
            
        }
        // Knapp för att signa in user 
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            string username = tbUserName.Text;
            string password = pbPassword.Password;

            bool isFoundUser = false;

            foreach (User user in _userManager.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    isFoundUser = true;

                    if (user is User)
                    {
                        Window travelWindow = new TravelWindow(_userManager, user);
                        travelWindow.Show();
                    }
                    else if (user is Admin)
                    {
                        Window travelwindow = new TravelWindow(_userManager, user);
                    }
                }
            }

            // Meddelande om user skriver något inkorrekt
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Kurwa... Co robisz?? ");
            }

        }


    }
}
