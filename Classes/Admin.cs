using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Classes
{
    public class Admin : IUser
    {
        public string Username { get; set; } 
        public string Password { get; set; } 
        public Countries Location { get;set; }

        //public void AddAdminUser()
        //{
        //    Admin admin = new("admin", "password");

        //    users.Add(admin);
        //}
    }
}
