using BOL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BOL.Models
{
    public class Helper:IHelper
    {
        private readonly IConfiguration _configuration;
        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Constr(string name)
        {
            return _configuration.GetConnectionString(name);
        }
    }
}
