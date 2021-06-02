using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MVCPetsShop.Interfaces;
using MVCPetsShop.Models;

namespace MVCPetsShop.Controllers
{
    public class PetShopController : Controller
    {
        //private IProductDataAccess _repo = new ProductRepository(new ProductDataAccess());
        private readonly IPetShopProductRepo _repo;
        public PetShopController(IPetShopProductRepo repo)
        {
            _repo = repo;
        }
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
        public IActionResult Edit(PetShopProduct product)
        {
            _repo.UpdateProduct(product);
            return View("Inventory",_repo.GetProducts());
        }

    }
}
