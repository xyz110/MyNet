using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace MyNet.Library.Data
{
    public  class DBPoolHelper
    {
        public static SqlConnectionStringBuilder SqlConPool = new SqlConnectionStringBuilder();

        public static OracleConnectionStringBuilder OracleConPool = new OracleConnectionStringBuilder();

        static DBPoolHelper()
        {
            SqlConPool.MaxPoolSize = 10;
            SqlConPool.MinPoolSize = 0;
            SqlConPool.Pooling = true;
            SqlConPool.Password = @"1qaz2wsx";
            SqlConPool.UserID = @"sa";
            SqlConPool.DataSource = @".";
            SqlConPool.InitialCatalog = @"myown";
            SqlConPool.ConnectTimeout = 1;

            OracleConPool.DataSource = "";
        }

        public DBPoolHelper() {
            //conPool.MaxPoolSize = 10;
            //conPool.MinPoolSize = 0;
            //conPool.Pooling = true;
            //conPool.Password = @"1qaz2wsx";
            //conPool.UserID = @"sa";
            //conPool.DataSource = @".";
            //conPool.InitialCatalog = @"myown";
            //conPool.ConnectTimeout = 1;
        }

        public static void Test()
        {
            using (SqlConnection con = new SqlConnection(SqlConPool.ConnectionString))
            {
                try
                {
                    con.Open();
                    if (con != null)
                    {
                        Console.WriteLine(con.State);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        
    }
}
