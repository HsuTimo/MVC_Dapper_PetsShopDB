using BOL.Interfaces;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ProductRepository : IProductDataAccess
    {
        private readonly IProductDataAccess _productData;
        public ProductRepository(IProductDataAccess productData)
        {
            _productData = productData;
        }
        public void AddProduct(Product product)
        {
            _productData.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productData.DeleteProduct(id);
        }

        public List<Product> GetProducts()
        {
            return _productData.GetProducts();
        }
        public Product GetProduct(int id)
        {
            return _productData.GetProduct(id);
        }

        public void UpdateProduct(Product product)
        {
            _productData.UpdateProduct(product);
        }
    }
}
