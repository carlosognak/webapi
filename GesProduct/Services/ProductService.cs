using GesProduct.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesProduct.Services
{
    public class ProductService
    {
        //Pour récupérer la liste des Produits
        public static IEnumerable<Product> GetProducts()
        {
            var client = new RestClient("http://localhost:54120/api/Products/");
            var request = new RestRequest(Method.GET);
            // async with deserialization
            IRestResponse<List<Product>> response = client.Execute<List<Product>>(request);
            return response.Data.ToList();
        }

        //Pour afficher un utlisateur 
        public Product GetProduct(int id)
        {
            var client = new RestClient("http://localhost:54120/api/Products/" + id);
            var request = new RestRequest(Method.GET);
            IRestResponse<Product> response = client.Execute<Product>(request);
            return response.Data;
        }

        //Pour créer une nouve produit
        public static bool CreateProduct(Product product)
        {
            var client = new RestClient("http://localhost:54120/api/Products");
            var request = new RestRequest(Method.POST);
            {
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "multipart/form-data; boundary=---011000010111000001101001");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(product);
            }
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        //Pour les modifications sur le produit
        public static bool EditProduct(int id, Product product)
        {
            var client = new RestClient("http://localhost:54120/api/Products/"+id);
            var request = new RestRequest(Method.PUT);
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(product);
            }
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        //Pour supprimer un produit 
        public static bool DeleteProduct(int id)
        {
            var client = new RestClient("http://localhost:54120/api/Products/" + id);
            var request = new RestRequest(Method.DELETE);
            var response = client.Execute(request);
            return response.IsSuccessful;
        }




    }
}
