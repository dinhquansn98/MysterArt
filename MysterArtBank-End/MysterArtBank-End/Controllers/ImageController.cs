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
    public class ImageController : ApiController
    {
        [Route("GetAllImage")]
        [HttpGet]
        public List<Image> GetAllImage()
        {
            List<Image> listImage = new List<Image>();
            // khoi tao doi tuong conection 
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);

            // khoi tao doi tuong sqlcommand cho phep thao tac voi csdl
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SElECT * FROM images AS i ,Colection AS c WHERE c.ColectionID = i.ColectionID ";


            //Mo ket noi DB
            sqlConnection.Open();
            //sqlConnection1.Open();


            // thuc thi cau truy van 

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // xu ly ket qua tra ve
            while (sqlDataReader.Read())
            {
                var image = new Image();
                var colection = new Colection();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // lay ten cot du lieu dang doc
                    var colName = sqlDataReader.GetName(i);

                    // lay gia tri cot dang doc 

                    var value = sqlDataReader.GetValue(i);

                    // lay property co ten giong voi gia tri lay ra o tren

                    var property = image.GetType().GetProperty(colName);


                    if (colName == "ColectionID")
                    {
                        colection.ColectionID = Int32.Parse(value.ToString());
                    }
                    if (colName == "Name")
                    {
                        colection.Name = value.ToString();
                        var propertyColection = image.GetType().GetProperty("Colection");
                        propertyColection.SetValue(image, colection);
                    }


                    if (property != null)
                    {
                        property.SetValue(image, value);
                    }

                }

                // them doi tuong vao list
                listImage.Add(image);

            }
            //dong ket noi
            sqlConnection.Close();

            return listImage;
        }



        [Route("PostImage")]
        [HttpPost]
        public bool PostImage([FromBody] Image image)
        {
          
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;

            sqlCommand.CommandText = "INSERT INTO images(Link, ColectionID)VALUES(@Link,@ColectionID)";

            sqlCommand.Parameters.AddWithValue("@Link",image.Link);
            sqlCommand.Parameters.AddWithValue("@ColectionID",image.Colection.ColectionID);

            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;

        }

        [Route("EditImage")]
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {

          
        }

        [Route("DeleteImage")]
        [HttpDelete]
        public bool DeleteImage(int ImageID)
        {
            String conectionDB = "Data Source=DESKTOP-T9F2UQQ;Initial Catalog=MysterArtStudio;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conectionDB);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;

            sqlCommand.CommandText = " DELETE FROM images WHERE ImageID = @ImageID";

            sqlCommand.Parameters.AddWithValue("@ImageID",ImageID);

            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;
        }




    }
}
