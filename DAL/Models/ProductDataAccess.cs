using BOL.Interfaces;
using BOL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ProductDataAccess : IProductDataAccess
    {
        private IHelper _helper;
        public ProductDataAccess(IHelper helper)
        {
            _helper = helper;
        }
        public void AddProduct(Product product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(_helper.Constr("PetShopInventory")))
            {
                connection.Execute("AddProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProduct(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            using (IDbConnection connection = new SqlConnection(_helper.Constr("PetShopInventory")))
            {
                connection.Execute("DeleteProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Product> GetProducts()
        {
            using (IDbConnection connection = new SqlConnection(_helper.Constr("PetShopInventory")))
            {
                var sql = $"select * from PetShopInventory";
                var output = connection.Query<Product>(sql);
                return output.ToList();
            }
        }
        public Product GetProduct(int id)
        {
            using (IDbConnection connection = new SqlConnection(_helper.Constr("PetShopInventory")))
            {
                var sql = $"select * from PetShopInventory where ID = {id}";
                var output = connection.Query<Product>(sql).ToList().First();
                return output;
            }
        }

        public void UpdateProduct(Product product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", product.ID);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(_helper.Constr("PetShopInventory")))
            {
                connection.Execute("UpdateProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
