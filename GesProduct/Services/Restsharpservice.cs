using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesProduct.Services
{
    public class Restsharpservice
    {
        public RestClient client = new RestClient("http://localhost:54120/api/");
    }
}
