using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace backend_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MenuItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(string userRole)
        {


            string query = @"SELECT *
                          FROM MenuItems
                          Where MenuId IN (SELECT MenuId FROM RoleAccessMenuItems Where RoleId IN(SELECT RoleId From EmployeeRole Where Name='" + userRole + "'))";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");

            SqlDataReader myReader;

            using(SqlConnection conn=new SqlConnection(sqlDataSource))
            {
                conn.Open();
                using(SqlCommand cmd=new SqlCommand(query,conn))
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
