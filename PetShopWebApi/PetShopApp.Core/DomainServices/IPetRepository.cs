using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Coree.DomainServices
{
    public interface IPetRepository
    {

        Pet Create(Pet pet);

        Pet ReadById(int id);
        List<Pet> ReadAll();

        Pet Update(Pet petToUpdate);

        Pet Delete(int id);
        List<Pet> FilterPetByType(string type);
        List<Pet> GetPriceList();
    }
}
