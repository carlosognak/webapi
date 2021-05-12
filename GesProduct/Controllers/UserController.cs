using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GesProduct.Models;
using GesProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace GesProduct.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var listCat = UserService.GetUsers();
            return View(listCat);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var cat = UserService.GetUsers();
            var categ = cat.Where(c => c.IdUser == id).FirstOrDefault();
            return View(categ);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new Models.User());
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                UserService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var listUse = UserService.GetUsers();
            var categ = listUse.Where(c => c.IdUser == id).FirstOrDefault();
            return View(categ);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, User user)
        {
            try
            {
                // TODO: Add update logic here
                UserService.EditUser(id, user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = UserService.GetUsers();
            var categ = cat.Where(c => c.IdUser == id).FirstOrDefault();
            return View(categ);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UserService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}