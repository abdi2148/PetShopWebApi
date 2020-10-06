using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Coree.DomainServices
{
   public interface IOwnerRepository
    {
       public IEnumerable<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

        Owner Create(Owner owner);

        Owner Delete(int id);

        Owner Update(Owner ownerToUpdate);
    }
}
