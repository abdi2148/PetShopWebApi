using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Coree;
using PetShopApp.Core.Entities;
using PetShopApp.Coree.ApplicationServices.Services;

namespace PetShopApp.Infastructure.Static.Data
{
    public class DataInit
    {
        readonly IPetService _petService;

        public DataInit(IPetService petService)
        {
            _petService = petService;
        }

        public void InitData()
        {

            Pet pet1 = new Pet
            {
                Name = "Tony",
                Type = "Cat",
                Color = "Blue",
                Birthday = new DateTime(2016, 8, 3),
                SoldDate = new DateTime(2019, 5, 1),
                PrevOwner = "Mark Twain",
                Price = 405,
            };
            _petService.Create(pet1);

            Pet pet2 = new Pet
            {
                Name = "Lessy",
                Type = "Dog",
                Color = "Brown",
                Birthday = new DateTime(2017, 4, 5),
                SoldDate = new DateTime(2020, 1, 6),
                PrevOwner = "Bianca Bilorsen",
                Price = 320.60,
            };
            _petService.Create(pet2);

            Pet pet3 = new Pet
            {
                Name = "Mickey",
                Type = "Mouse",
                Color = "Black",
                Birthday = new DateTime(2015, 6, 3),
                SoldDate = new DateTime(2020, 4, 7),
                PrevOwner = "Tito Hendriks",
                Price = 320,
            };
            _petService.Create(pet3);

            Pet pet4 = new Pet
            {
                Name = "George",
                Type = "Pig",
                Color = "Pink",
                Birthday = new DateTime(2018, 4, 5),
                SoldDate = new DateTime(2020, 3, 7),
                PrevOwner = "Indiana Jones",
                Price = 180.60,
            };
            _petService.Create(pet4);

            Pet pet5 = new Pet
            {
                Name = "Barbie",
                Type = "Cat",
                Color = "Orange",
                Birthday = new DateTime(2018, 5, 11),
                SoldDate = new DateTime(2020, 4, 5),
                PrevOwner = "Jack Sparrow",
                Price = 7400,
            };
            _petService.Create(pet5);

            Pet pet6 = new Pet
            {
                Name = "Mozart",
                Type = "Dog",
                Color = "Green",
                Birthday = new DateTime(2018, 5, 7),
                SoldDate = new DateTime(2020, 2, 1),
                PrevOwner = "Oscar Wild",
                Price = 45.45,
            };
            _petService.Create(pet6);
        }


    }
}

