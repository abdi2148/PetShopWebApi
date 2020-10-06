using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Coree.ApplicationServices.Services
{
   public interface IOwnerService 
    {
        

        List<Owner> GetAllOwners();

        Owner FindOwnerById(int id);

        Owner Update(Owner owner);

        Owner Delete(int id);

        Owner Create(Owner owner);
        Owner GetOwnerByIdIncludePets(int id);

    }
}
