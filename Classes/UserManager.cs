using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Classes
{
    public class UserManager
    {
        public List<IUser> Users { get; set; }
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            Users = new List<IUser>();
            Users.Add(
                new User
                {
                    Username = "Gandalf",
                    Password = "password",
                    Location = Countries.Bosnia_and_Herzegovina,
                    Travels = new List<Travel>()
                    {
                        new Trip(TripTypes.Work, "Borås", Countries.Bangladesh, 1 ),
                        new Vacation(false, "Kandahar", Countries.Sweden, 5)
                    }
                });
            
            
            AddAdminUser();
        }
        // Kunna tillägga en användare
        public bool addUser(string username, string password, Countries country)
        {
            if (ValidateUsername(username))
            {
                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Location = country,
                    Travels = new()
                };

                Users.Add(newUser);

                return true;
            }
            return false;
        }
        // Kunna skapa en admin
        public void AddAdminUser()
        {
            Admin admin = new();

            admin.Username = "admin";
            admin.Password = "password";

            Users.Add(admin);
        }
        // Ta bort en användare
        public bool removeUser(User user)
        {
            if (Users.Any(x => x.Username == user.Username))
            {
                Users.Remove(user);

                return true;
            }

            return false;
        }
        // Uppdatera användarens namn
        public bool UpdateUserName(User user, string updatedUserName)
        {
            user.Username = updatedUserName;
            return true;
        }
        // Validera användaren 
        private bool ValidateUsername(string username)
        {
            bool usernameIsValid = true;

            if (string.IsNullOrEmpty(username) || Users.Any(x => x.Username == username))
                usernameIsValid = false;

            return usernameIsValid;
        }
        // Signa in en användare
        public bool SignInUser(string username, string password)
        {
            return true;
        }
        // Uppdatera lösenord
        public bool UpdatePassword(User user, string updatedPassword)
        {
            user.Password = updatedPassword;
            return true;
        }
        // Uppdatera landet
        public bool UpdateCountry(User user, Countries country)
        {
            user.Location = country;
            return true;
        }
        // Admin kan radera användarens travel
        public bool AdminRemoveTravel(int index, string userName)
        {
            List<Travel> travelList = new();

            foreach (User user in Users.Where(x => x.GetType() == typeof(User)).ToList())
            {
                foreach(Travel travel in user.Travels)
                    travelList.Add(travel);
            }

            Travel travelToRemove = travelList.ElementAt(index);

            User userWithTravelToDelete = (User)Users.FirstOrDefault(x => x.Username == userName);

            userWithTravelToDelete.Travels.Remove(travelToRemove);

            return true;
        }

    }
}
