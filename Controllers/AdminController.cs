using EMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMedicine.Controllers
{
    public class AdminController
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdatedMedicine")]
        public Response AddUpdatedMedicine(Medicines medicines)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Response response = dal.AddUpdateMedicine(medicines, connection);
            return response;
        }
    }
}
