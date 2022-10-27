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
using TravelPal.Interface;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        
        // Använda sig av textboxes istället och implementera med hjälp av 

        // casta users location som integer och sätta sedan combobox i selected index, sätta combobox.isEnabled till false = visas en combobox du nt kan ändra
        public TravelDetailsWindow()
        {
            InitializeComponent();



            //lblDisplayUser.Content = _user.Username;
        }

        private void btnTravelBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
