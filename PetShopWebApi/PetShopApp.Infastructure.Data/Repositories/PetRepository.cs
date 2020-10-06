using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;
using PetShopApp.Coree.DomainServices;
using System.Linq;

namespace PetShopApp.Infastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {

        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            Pet petFound = this.ReadById(id);
            if (petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        public List<Pet> FilterPetByType(string type)
        {
            return _pets.Where(x => x.Type == type).ToList();

        }

        public List<Pet> GetPriceList()
        {
            return _pets.OrderBy(x => x.Price).ToList();
        }

        public List<Pet> ReadAll()
        {
            return _pets;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petToUpdate)
        {
            var petFromDB = this.ReadById(petToUpdate.Id);
            if(petFromDB != null)
            {
                petFromDB.Name = petToUpdate.Name;
                petFromDB.PrevOwner = petToUpdate.PrevOwner;
                petFromDB.Price = petToUpdate.Price;
                petFromDB.Color = petToUpdate.Color;
                petFromDB.Birthday = petToUpdate.Birthday;
                petFromDB.SoldDate = petToUpdate.SoldDate;

                return petFromDB;
            }
            return null;
        }
    }
}
