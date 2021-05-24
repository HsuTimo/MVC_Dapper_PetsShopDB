using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Interfaces
{
    public interface IProductDataAccess
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
