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
    public class ColectionController : ApiController
    {

        [Route("GetColection")]
        [HttpGet]
        public List<Colection> GetService()
        {

            List<Colection> listcolection = new List<Colection>();
            // khoi tao doi tuong conection 
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);

            // khoi tao doi tuong sqlcommand cho phep thao tac voi csdl
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SElECT * FROM Colection ";

            //Mo ket noi DB
            sqlConnection.Open();
            //sqlConnection1.Open();


            // thuc thi cau truy van 

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                var colection = new Colection();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // lay ten cot du lieu dang doc
                    var colName = sqlDataReader.GetName(i);

                    // lay gia tri cot dang doc 

                    var value = sqlDataReader.GetValue(i);

                    // lay property co ten giong voi gia tri lay ra o tren

                    var property = colection.GetType().GetProperty(colName);


                    if (property != null)
                    {
                        property.SetValue(colection, value);
                    }

                }
                listcolection.Add(colection);

            }


            return listcolection;
        }

        // GET: api/Colection/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Colection

        [Route("PostColection")]
        [HttpPost]
        public bool PostColection([FromBody] Colection colection)
        {

            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;

            sqlCommand.CommandText = "INSERT INTO Colection(Name,ServiceID)VALUES(@Name,@ServiceID)";

            sqlCommand.Parameters.AddWithValue("@Name", colection.Name);
            sqlCommand.Parameters.AddWithValue("@ServiceID", colection.Service.ServiceID);

            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;
        }

        // PUT: api/Colection/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Colection/5
        public void Delete(int id)
        {
        }
    }
}
