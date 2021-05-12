using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GesProduct.Models;
using GesProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace GesProduct.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var listPro = ProductService.GetProducts();
            return View(listPro);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Listcat = CategoryService.GetCategories();
            var pro = ProductService.GetProducts();
            var prod = pro.Where(c => c.IdPro == id).FirstOrDefault();
            return View(prod);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Listcat = CategoryService.GetCategories();
            return View(new Models.Product());
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                // Récuperation des donnée saisies
                string NomPro = HttpContext.Request.Form["NomPro"];
                string DesPro = HttpContext.Request.Form["DesPro"];
                IFormFile ImagePro = HttpContext.Request.Form.Files.FirstOrDefault();
                Stream stream = ImagePro.OpenReadStream();
                int IdCat = int.Parse(HttpContext.Request.Form["IdCat"]);


                //Création d'un nouveau produit
                var client = new RestClient("http://localhost:54120/api/Products");
                var request = new RestRequest(Method.POST);
                {
                    request.AddHeader("Content-Type", "multipart/form-data");
                    client.AddDefaultParameter("NomPro", NomPro);
                    client.AddDefaultParameter("DesPro", DesPro);
                    //client.AddDefaultParameter("ImagePro", ImagePro);
                    request.AddFile("ImagePro", ReadFully(stream), ImagePro.FileName, "application/octet-stream");
                    client.AddDefaultParameter("IdCat", IdCat);
                }

                var response = client.Execute(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Listcat = CategoryService.GetCategories();
            var listpro = ProductService.GetProducts();
            var pro = listpro.Where(c => c.IdPro == id).FirstOrDefault();
            return View(pro);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Product product)
        {
            try
            {
                // TODO: Add update logic here
                ProductService.EditProduct(id, product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = ProductService.GetProducts();
            var prod = pro.Where(c => c.IdPro == id).FirstOrDefault();
            return View(prod);
        }


        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProductService.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}