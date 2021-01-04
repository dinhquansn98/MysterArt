using MysterArtBank_End.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MysterArtBank_End.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceController : ApiController
    {


        [Route("GetService")]
        [HttpGet]
        public List<Service> GetService()
        {

            List<Service> listservice = new List<Service>();
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SElECT * FROM Service ";

            sqlConnection.Open();
            

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                var service = new Service();

                for(int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                   
                    var colName = sqlDataReader.GetName(i);

              

                    var value = sqlDataReader.GetValue(i);

                

                    var property = service.GetType().GetProperty(colName);


                    if (property != null)
                    {
                        property.SetValue(service, value);
                    }

                }

                listservice.Add(service);
            }


            return listservice;
        }

        // POST: api/Service

        [Route("PostService")]
        [HttpPost]
        public bool Post([FromBody]Service service)
        {

            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;

            sqlCommand.CommandText = "INSERT INTO Service(Name, LinkAvartar)VALUES(@Name,@LinkAvartar)";

            sqlCommand.Parameters.AddWithValue("@Name", service.Name);
            sqlCommand.Parameters.AddWithValue("@LinkAvartar", service.LinkAvartar);

            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5

        [Route("DeleteService")]
        [HttpDelete]
        public bool DeleteService(int ServiceID)
        {
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;

            sqlCommand.CommandText = " DELETE FROM Service WHERE ServiceID = @ServiceID";

            sqlCommand.Parameters.AddWithValue("@ServiceID", ServiceID);

            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;
        }
    }
}
