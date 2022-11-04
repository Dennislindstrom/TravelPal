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

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        // Info ruta som dyker upp med roligt filmklipp 
        public InfoWindow()
        {
            InitializeComponent();
        }
        // knapp som får användaren att ta bort fönstret när man trycker på "back"
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
