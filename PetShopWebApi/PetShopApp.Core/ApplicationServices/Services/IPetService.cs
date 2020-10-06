using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Coree.ApplicationServices.Services
{
    public interface IPetService
    {
        Pet CreateNewPet( string Name,
                    string Type,
                    DateTime BirthdayDate,
                    DateTime SoldDate,
                    string Color,
                    double Price,
                    string prevOwner);
        List<Pet> GetPets();

        Pet FindPetById(int id);
        
        Pet Update(Pet pet);

        Pet Delete(int id);

        Pet Create(Pet pet);

        List<Pet> FilterPetByType(string type);
        List<Pet> GetSortedList();
    }
}
    