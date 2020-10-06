using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int PhoneNumber   { get; set; }
        public string Address { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public Pet Pet { get; set; }

    }
}
