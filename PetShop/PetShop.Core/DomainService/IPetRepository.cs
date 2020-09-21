using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
        public  interface IPetRepository
    {
        Pet Create (Pet pet);
        Pet ReadById(int id);
        List<Pet> ReadAll();
        Pet Update(Pet updatePet);
        Pet Delete(int id);
        void InitialiseData();
    }
}
