using GesProduct.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesProduct.Services
{
    public class UserService
    {
        //Pour récupérer la liste des Utilisateurs
        public static IEnumerable<User> GetUsers()
        {
            var client = new RestClient("http://localhost:54120/api/Users/");
            var request = new RestRequest(Method.GET);
            // async with deserialization
            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            return response.Data.ToList();
        }

        //Pour afficher un utlisateur 
        public User GetUser(int id)
        {
            var client = new RestClient("http://localhost:54120/api/Users/" + id);
            var request = new RestRequest(Method.GET);
            IRestResponse<User> response = client.Execute<User>(request);
            return response.Data;
        }

        //Pour créer un nouveau  utilisateur
        public static bool CreateUser(User user)
        {
            var client = new RestClient("http://localhost:54120/api/Users");
            var request = new RestRequest(Method.POST);
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(user);
            }
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        //Pour les modifications sur un utilisateur
        public static bool EditUser(int id, User user)
        {
            var client = new RestClient("http://localhost:54120/api/Users/" + id);
            var request = new RestRequest(Method.PUT);
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(user);
            }
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        //Pour supprimer un utilisateur
        public static bool DeleteUser(int id)
        {
            var client = new RestClient("http://localhost:54120/api/Users/"+id);
            var request = new RestRequest(Method.DELETE);
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

    }
}
