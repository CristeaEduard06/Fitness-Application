using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_POO_GYM
{
    internal class Subscription
    {
        public string Name { get; set; }

        public string Sex { get; set; }

        public string Location { get; set; }

        public string Type { get; set; }

        public Subscription(string name, string sex, string location, string type)
        {
            Name = name;
            Sex = sex;
            Location = location;
            Type = type;
        }
    }
}
