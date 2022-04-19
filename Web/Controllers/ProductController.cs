using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Interface;
using Web.Models.Repository;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepositoty productRepositoty;

        public ProductController()
        {
            productRepositoty = new ProductRepository();
        }

        public IActionResult Index()
        {
            var data = productRepositoty.GetAll().ToList();
            return View(data);
        }
    }
}
