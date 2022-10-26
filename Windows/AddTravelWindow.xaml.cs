using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        // Öppna fönstret och displaya val av resor 
        public AddTravelWindow()
        {
            InitializeComponent();

            cbAddCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            cbAddCountry.SelectedIndex = 0;

            cbAddTrip.ItemsSource = Enum.GetValues(typeof(TripTypes));
            cbAddTrip.SelectedIndex = 0;


        }
        //Cancel knapp 
        private void btnAddTravelCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //Spara användarens val 
        private void btnAddTravelSave_Click(object sender, RoutedEventArgs e)
        {
            string destination = tbDestination.Text;
            string country = cbAddCountry.Text;
            int travelers = Convert.ToInt32(tbTravelers.Text);

            try
            {
                Convert.ToInt32(tbTravelers.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kurwa siffror!", "REFERENSNAMBER");
            }
        }
    }
}
