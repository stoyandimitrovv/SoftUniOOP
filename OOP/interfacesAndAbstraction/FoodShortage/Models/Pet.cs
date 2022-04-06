using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : IBirtable
    {
        public Pet(string name, string birthdate)
        {        
            Name = name;
            Birthdate = birthdate;
        }

        public string Birthdate { get; set; }

        public string Name { get; set; }
    }
}
