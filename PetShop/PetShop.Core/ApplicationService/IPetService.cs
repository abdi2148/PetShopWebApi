using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //Creates petId
        Pet CreatePet(Pet pe);
        //Reads petID
        Pet FindPetById(int id);
        List<Pet> GetPets();
        //Updates pet
        Pet UpdatePet(Pet petUpdate);

        //Deletes pet
        Pet DeletePet(int id);
        Pet NewPet(string name, string type, string previousOwner, double price, DateTime soldDate, DateTime birthdate, string color);
        List<Pet> getASC();
        List<Pet> getDESC();
        List<Pet> getCheapest();
        List<Pet> getAllByType(string chosenType);
        void InitDatabaseData();
    }
}
