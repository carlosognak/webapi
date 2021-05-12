using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ProductContext _context;

        public LoginController(ProductContext context)
        {
            _context = context;
        }

        private bool UserLogExists(string login, string mpd)
        {
            if (login!= null && mpd != null)
            {
                return _context.Users.Any(e => e.Login == login && e.Mdp == mpd);
            }
            else
            {
                return false;
            }
           
        }

        [HttpPost]
        public User Login([FromBody] LoginModel login)
        {

            if (UserLogExists(login.Username, login.Password))
            {
                return _context.Users.Where(u => u.Login == login.Username && u.Mdp == login.Password).First();
            }
            return null;
        }
    }
}