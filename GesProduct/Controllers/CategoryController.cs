using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GesProduct.Models;
using GesProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GesProduct.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var listCat = CategoryService.GetCategories();
            return View(listCat);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var cat = CategoryService.GetCategories();
            var categ = cat.Where(c => c.IdCat == id).FirstOrDefault();
            return View(categ);
        }

        //// GET: Category/Create
        public ActionResult Create()
        {
            return View(new Models.Category());
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            { // TODO: Add insert logic here

                CategoryService.CreateCategory(category);
              
             return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var listCat = CategoryService.GetCategories();
            var categ = listCat.Where(c=> c.IdCat == id).FirstOrDefault();
            return View(categ);
        }

        // POST: Category/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection ,Category category)
        {
            try
            {
                // TODO: Add update logic here
                CategoryService.EditCategory(id,category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = CategoryService.GetCategories();
            var categ = cat.Where(c => c.IdCat == id).FirstOrDefault();
            return View(categ);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CategoryService.DeleteCategory(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}