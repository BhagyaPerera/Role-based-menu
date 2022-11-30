using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace backend_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(string userId, string password)
        {


            string query = @"SELECT *
                          FROM Employees WHERE UserId='" + userId + "' AND Password='" + password+"'";
                          


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");

            SqlDataReader myReader;

            using (SqlConnection conn = new SqlConnection(sqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    conn.Close();
                }
            }
            return new JsonResult(table);
        }

    }
}
