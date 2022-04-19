using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DBEntities;
using Web.Models.Interface;
using Web.Models.Repository;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepositoty categoryRepositoty;

        public CategoryController(ICategoryRepositoty _categoryRepositoty)
        {
            categoryRepositoty = _categoryRepositoty;
        }

        public IActionResult Index()
        {
            var data = categoryRepositoty.GetAll().ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category != null && ModelState.IsValid)
            {
                categoryRepositoty.Create(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = categoryRepositoty.Get(id.Value);
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category != null && ModelState.IsValid)
            {
                categoryRepositoty.Update(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = categoryRepositoty.Get(id.Value);
                categoryRepositoty.Delete(category);

                return RedirectToAction("index");
            }
        }
    }
}
