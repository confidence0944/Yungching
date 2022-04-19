using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Interface;
using Web.Models.Repository;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepositoty categoryRepositoty;

        public CategoryController()
        {
            categoryRepositoty = new CategoryRepository();
        }

        public IActionResult Index()
        {
            var data = categoryRepositoty.GetAll().ToList();
            return View(data);
        }
    }
}
