﻿using System;
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
    /// Interaction logic for TravelWindow.xaml
    /// </summary>
    public partial class TravelWindow : Window
    {


        private List<Travel> travels = new();

        private readonly UserManager _userManager;

        private readonly User _user;
        private readonly Admin _admin;
        private bool _isAdmin = false;
        private readonly MainWindow _mainWindow;

        public TravelWindow()
        {
            InitializeComponent();
            DisplayTravels();
        }



        public TravelWindow(UserManager userManager, IUser user, MainWindow mainWindow)
        {
            InitializeComponent();
            if (user.GetType() == typeof(User))
            {
                _user = (User)user;
                travels = _user.Travels;
                lblDisplayUser.Content = _user.Username;

            }
            else
            {
                btnAddTravel.IsEnabled = false;
                btnUserDetails.IsEnabled = false;
                _admin = (Admin)user;
                lblDisplayUser.Content = "ADMIN";
                _isAdmin = true;
            }
            _userManager = userManager;
            _mainWindow = mainWindow;

            DisplayTravels();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            Window addTravelWindow = new AddTravelWindow(_user, this);
            addTravelWindow.Show();
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            Window userDetailswindow = new UserDetailsWindow(_userManager, _user, this);
            userDetailswindow.Show();


        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            if(!_isAdmin)
                MessageBox.Show($"Bye, {_user.Username}. please give G as slutbetyg");
            _mainWindow.Show();


        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Window infoWindow = new InfoWindow();
            infoWindow.Show();

        }

        private void btnTravelDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lvTravels.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a travel first!", "Error");
                return;
            }
            Travel selectedTravel = travels[lvTravels.SelectedIndex];
            if (selectedTravel.GetType().Equals(typeof(Vacation)))
            {
                Window travelDetailsWindow = new TravelDetailsWindow((Vacation)selectedTravel);
                travelDetailsWindow.Show();
            }
            else
            {
                Window travelDetailsWindow = new TravelDetailsWindow((Trip)selectedTravel);
                travelDetailsWindow.Show();
            }

        }
        public void DisplayTravels()
        {
            lvTravels.Items.Clear();

            if (_isAdmin)
            {
                List<IUser> usersList = _userManager.Users.Where(x => x.GetType() == typeof(User)).ToList();

                foreach (User user in usersList)
                {
                    foreach (Travel travel in user.Travels)
                    {
                        travels.Add(travel);
                        ListViewItem listViewItem = new ListViewItem();

                        listViewItem.Tag = travel;
                        listViewItem.Content = $"User: {user.Username} Trip: {travel.Destination} | Country: {travel.Country.ToString()} | Travelers: {travel.Travellers.ToString()}";

                        lvTravels.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                travels = _user.Travels;
                foreach (Travel travel in travels)
                {

                    ListViewItem listViewItem = new ListViewItem();

                    listViewItem.Tag = travel;
                    listViewItem.Content = $"Trip: {travel.Destination} | Country: {travel.Country.ToString()} | Travelers: {travel.Travellers.ToString()}";

                    lvTravels.Items.Add(listViewItem);
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            lvTravels.Focus();

            if (lvTravels.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a travel first!", "Error!");
                lvTravels.SelectedIndex = -1;
                return;
            }


            Travel selectedTravel = travels[lvTravels.SelectedIndex];

            if(_isAdmin)
            {
                string userName = (string)lvTravels.SelectedItems[0].ToString().Split(" ")[2];
                _userManager.AdminRemoveTravel(lvTravels.SelectedIndex, userName);
                UpdateGUI();
                return;
            }

            if (selectedTravel.GetType().Equals(typeof(Vacation)))
                travels.Remove((Vacation)selectedTravel);

            if (selectedTravel.GetType().Equals(typeof(Trip)))
                travels.Remove((Trip)selectedTravel);

            UpdateGUI();
        }

        public void UpdateGUI()
        {
            if(!_isAdmin)
                lblDisplayUser.Content = _user.Username;

            DisplayTravels();
        }
    }
}
