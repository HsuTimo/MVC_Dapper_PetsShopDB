using MVCPetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPetsShop.Interfaces
{
    public interface IPetShopProductRepo
    {
        List<PetShopProduct> GetProducts();
        PetShopProduct GetProduct(int id);
        void AddProduct(PetShopProduct product);
        void UpdateProduct(PetShopProduct product);
        void DeleteProduct(int id);
    }
}
