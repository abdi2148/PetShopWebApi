using PetShopApp.Core.Entities;
using PetShopApp.Coree.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Coree.ApplicationServices.Services.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;
        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }
        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }


        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }

       

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners().ToList();
        }

        public Owner Update(Owner ownerToUpdate)
        {
            return _ownerRepository.Update(ownerToUpdate);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            throw new NotImplementedException();
        }
    }
}
