using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopApp.Infrastructure.Data
{
    public static class FakeDB
    {

        private static List<Pet> allPets = new List<Pet>();
        static int id = 1;
        public static List<Pet> InitData()
        {
            var pet1 = new Pet()
            {
                Id = id++, Name = "Bob", PreviousOwner = "Abdi", Type = "Dog", Price = 1000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Black/White"
            };
            allPets.Add(pet1);

            var pet2 = new Pet()
            {
                Id = id++,
                Name = "Leet", PreviousOwner = "Adam", Type = "Cat", Price = 1337,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "White"
            };
            allPets.Add(pet2);

            var pet3 = new Pet()
            {
                Id = id++,
                Name = "Bentley", PreviousOwner = "Cooper", Type = "Goat", Price = 50000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Grey/White"
            };
            allPets.Add(pet3);

            var pet4 = new Pet()
            {
                Id = id++,
                Name = "Alex", PreviousOwner = "Ruby", Type = "Fox", Price = 1000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Brown/Orange"
            };

            allPets.Add(pet4);
            var pet5 = new Pet()
            {
                Id = id++,
                Name = "Pepe", PreviousOwner = "4chan", Type = "Frog", Price = 420,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Green"
            };

            allPets.Add(pet5);
            var pet6 = new Pet()
            {
                Id = id++,
                Name = "Jolly", PreviousOwner = "Golly", Type = "Pet Rock", Price = 4500000000000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Grey/White"
            };

            allPets.Add(pet6);

            return allPets;
        }

        public static int getID()
        {
            return id;
        }
    }
}
