using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BOL.Models
{
    public class Helper
    {
        public static string Constr(string name)
        {
            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return @"Server=.\SQLEXPRESS;Database=PetShopDB;Trusted_Connection=True;";
        }
    }
}
