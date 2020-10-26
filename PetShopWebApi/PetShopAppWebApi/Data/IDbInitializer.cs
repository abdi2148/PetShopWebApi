using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAppWebApi.Data
{
    public interface IDbInitializer
    {
        void Initialize(TodoContext context);
    }
}
