using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPetsShop.Models
{
    public static class Helper
    {
        public static string Constr(IConfiguration configuation, string name)
        {
            return configuation.GetConnectionString(name);
        }
    }
}
