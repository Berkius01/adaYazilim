using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using adaYazilim.Models;
using Newtonsoft.Json.Linq;

namespace adaYazilim.Controllers
{
    [Route("ada/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TrainService _ts;

        public TrainController(IConfiguration config)
        {
            config = _configuration;
            _ts = new TrainService();
        }
        
        public int capacity;
        public int fullness;
        public List<Boolean> percentile = new List<Boolean>();
        [HttpPost]
        public JsonResult Post(Train baskent) {
            //JsonResult val1 = _ts.Assign(baskent);
            //var jBaskent = (JObject)JToken.FromObject(baskent);

            //System.Diagnostics.Debug.WriteLine(baskent.name);
            /*
            string query = @"insert into tablo ";
            SqlDataReader myReader;
            string sqlDataSource = _configuration.GetConnectionString("TrainCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource)) {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
                
            }
            foreach (var val in baskent.carriage)
            {
                
                capacity = val["Kapasite"];
                fullness = val["DoluKoltukAdet"];
                if (fullness / capacity <= 70 / 100)
                {
                    percentile.Add(true);
                }
                else {
                    percentile.Add(false);
                }

            }*/
            return _ts.Assign(baskent);
        }
    }
}
