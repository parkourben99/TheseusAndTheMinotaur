using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;


namespace StorageManagement
{
    // will be a class for sql stuff when we can do that
    public static class Connector
    {
       public static SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

        public static void createDatabase()
        {
            string str;
            str = "DROP DATABASE IF EXISTS `squill`;CREATE DATABASE squill;USE squill;";
            SqlCommand myCommand = new SqlCommand(str, myConn);
        }
    } 
}
