using Dapper;
using Microsoft.Extensions.Configuration;
using MVCPetsShop.Interfaces;
using MVCPetsShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPetsShop.Repositories
{
    public class PetShopProductRepo : IPetShopProductRepo
    {
        private readonly IConfiguration _configuration;
        public PetShopProductRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void AddProduct(PetShopProduct product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration,"DefaultConnection")))
            {
                connection.Execute("AddProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProduct(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                connection.Execute("DeleteProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
        public PetShopProduct GetProduct(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                var sql = $"select * from PetShopInventory where ID = {id}";
                var output = connection.Query<PetShopProduct>(sql).First();
                return output;
            }
        }

        public List<PetShopProduct> GetProducts()
        {
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                var sql = $"select * from PetShopInventory";
                var output = connection.Query<PetShopProduct>(sql);
                return output.ToList();
            }
        }

        public void UpdateProduct(PetShopProduct product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", product.ID);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Quantity", product.Quantity);
            param.Add("@Price", product.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration,"DefaultConnection")))
            {
                connection.Execute("UpdateProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
