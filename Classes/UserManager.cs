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
        }

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

        public bool removeUser(User user)
        {
            if (Users.Any(x => x.Username == user.Username))
            {
                Users.Remove(user);

                return true;
            }

            return false;
        }

        public bool UpdateUserName(User user, string updatedUserName)
        {
            return true;
        }

        private bool ValidateUsername(string username)
        {
            return true;
        }

        public bool SignInUser(string username, string password)
        {
            return true;
        }

    }
}
