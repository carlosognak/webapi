using GesProduct.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesProduct.Services
{
    public class CategoryService
    {   //Pour récupérer la liste des catégories
        public static IEnumerable<Category> GetCategories()
        {
            var client = new RestClient("http://localhost:54120/api/Categories/");
            var request = new RestRequest(Method.GET);
            // async with deserialization
            IRestResponse<List<Category>> response = client.Execute<List<Category>>(request);

            return response.Data.ToList();
        }


        //Pour afficher un catégorie 
        public Category GetCategory( int id)
        {
            var client = new RestClient("http://localhost:54120/api/Categories/" + id);
            var request = new RestRequest(Method.GET);
            IRestResponse<Category> response = client.Execute<Category>(request);
            return response.Data;
        }


        //Pour créer une nouvelle catégorie
        public static bool CreateCategory(Category category)
        {
            var client = new RestClient("http://localhost:54120/api/Categories");
            var request = new RestRequest(Method.POST);
            { 
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(category);
            }
            var response = client.Execute(request);
            return response.IsSuccessful ;
        }

        //Pour les modifications sur la catégorie
        public static bool EditCategory(int id ,Category category)
        {
            var client = new RestClient("http://localhost:54120/api/Categories/"+id);
            var request = new RestRequest(Method.PUT);
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(category);
            }
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        //Pour supprimer une catégorie 
        public static bool  DeleteCategory(int id)
        {
            var client = new RestClient("http://localhost:54120/api/Categories/"+id);
            var request = new RestRequest(Method.DELETE);
            var  response = client.Execute(request);
            return response.IsSuccessful;
        }


    }
}
