using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysterArtBank_End.ConnectDB
{
    public class MyDatabaseConnection
    {
        public String connectionString { get; set; }

        public MyDatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
            // create a database connection perhaps
        }
        // some methods for querying a database
        public void execute(string query) {
        
        }
    }
}