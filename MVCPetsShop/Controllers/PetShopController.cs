using BLL.Models;
using BOL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BOL.Models;

namespace MVCPetsShop.Controllers
{
    public class PetShopController : Controller
    {
        private IProductDataAccess _repo = new ProductRepository(new ProductDataAccess());
        public IConfiguration configuration;
        public IActionResult Inventory()
        {
            var products = _repo.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _repo.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.UpdateProduct(product);
            return View("Inventory",_repo.GetProducts());
        }

    }
}
