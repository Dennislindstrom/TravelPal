﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; } 
        public int Travellers { get; set; }

        public Travel(string destination, Countries country, int travellers)
        {

        }

        public virtual string GetInfo()
        {
            return null;
        }
    }
}
