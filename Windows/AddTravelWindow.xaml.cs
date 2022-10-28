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

        private readonly User _user;
        private readonly TravelWindow _travelWindow;

        public AddTravelWindow(User user, TravelWindow travelWindow)
        {
            InitializeComponent();
            _user = user;
            _travelWindow = travelWindow;
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
            Countries country = (Countries)cbAddCountry.SelectedIndex;
            

            try
            {
                int travelers = int.Parse(tbTravelers.Text);

                Travel travel = new Travel(destination, country, travelers);
                _user.Travels.Add(travel);
                _travelWindow.DisplayTravels();
                Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
    }
}
