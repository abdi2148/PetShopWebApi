using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.Entities;
using PetShopApp.Coree.DomainServices;

namespace PetShopApp.Coree.ApplicationServices.Services.Implementation
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository PetRepository)
        {
            _petRepository = PetRepository;
        }

        public Pet CreateNewPet(string Name, string Type, DateTime BirthdayDate, DateTime SoldDate, string Color, double Price, string prevOwner)
        {
            Pet pet = new Pet
            {
                Name = Name,
                Type = Type,    
                Birthday = BirthdayDate,
                SoldDate = SoldDate,
                Color = Color,
                Price = Price,
                PrevOwner = prevOwner
            };
            _petRepository.Create(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet Update(Pet petToUpdate)
        {
            var pet = FindPetById(petToUpdate.Id);
            petToUpdate.Name = pet.Name;
            petToUpdate.PrevOwner = pet.PrevOwner;
            petToUpdate.Price = pet.Price;
            petToUpdate.SoldDate = pet.SoldDate;
            petToUpdate.Type = pet.Type;
            return pet;
        }

        public Pet FindPetById(int id)
        {
            return _petRepository.ReadById(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadAll().ToList();
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        public List<Pet> FilterPetByType(string type)
        {
            return _petRepository.FilterPetByType(type);
        }

        public List<Pet> GetSortedList()
        {
            return _petRepository.GetPriceList();
        }
    }
}
