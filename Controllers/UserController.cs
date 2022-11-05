using EMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection sqlConnection = new SqlConnection
                (_configuration.GetConnectionString("EMedCS").ToString());
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login (Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("").ToString());
            Response response = dal.Login(users, connection);
            return response;
        }

        [HttpPost]
        [Route("viewUser")]
        public Response ViewUser(Users user)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dAL.ViewUser(user, connection);
            return response;
        }

        [HttpPost]
        [Route("updateProfile")]
        public Response UpdateProfile(Users user)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dAL.UpdateProfile(user, connection);
            return response
        }
    }
}
