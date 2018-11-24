using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;


namespace MyNet.Library.Data
{
    public class DBHelper
    {
        public static string MySqlConString = ConfigurationManager.ConnectionStrings["MySqlCon"].ToString();

        public static string OracleConString = ConfigurationManager.ConnectionStrings["OracleCon"].ToString();

        public static string SqlServerConString = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();

        public static MySqlConnection GetMySqlCon()
        {
            MySqlConnection con = new MySqlConnection(MySqlConString);
            con.Open();
            return con;
        }

        public static SqlConnection GetSqlServerCon()
        {
            SqlConnection con = new SqlConnection(SqlServerConString);
            con.Open();
            return con;
        }

        public static OracleConnection GetOracleCon()
        {
            OracleConnection con = new OracleConnection(OracleConString);
            con.Open();
            return con;
        }

        public static void CloseCon(MySqlConnection con)
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }

        public static void CloseCon(SqlConnection con)
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }

        public static void CloseCon(OracleConnection con)
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
        public static DataTable ExecuteQueryMySql(string text)
        {
            MySqlConnection con = null;
            try
            {
                con = GetMySqlCon();
                MySqlDataAdapter adapter = new MySqlDataAdapter(text, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteQueryMySql(string text,MySqlConnection con)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(text, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static  object ExecuteScalarMySql(string text)
        {
            MySqlConnection con = null;
            try
            {
                con = GetMySqlCon();
                MySqlCommand command = new MySqlCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static object ExecuteScalarMySql(string text, MySqlConnection con)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteProcedureMySql(string proName, params string[] str )
        {
            MySqlConnection con = null;
            try
            {
                con = GetMySqlCon();
                MySqlCommand command = new MySqlCommand(proName, con);
                command.CommandType = CommandType.StoredProcedure;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteQueryOracle(string text)
        {
            OracleConnection con = null;
            try
            {
                con = GetOracleCon();
                OracleDataAdapter adapter = new OracleDataAdapter(text, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteQueryOracle(string text, OracleConnection con)
        {
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(text, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static object ExecuteScalarOracle(string text)
        {
            OracleConnection con = null;
            try
            {
                con = GetOracleCon();
                OracleCommand command = new OracleCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static object ExecuteScalarOracle(string text, OracleConnection con)
        {
            try
            {
                OracleCommand command = new OracleCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static DataTable ExecuteProcedureMySql(string proName, Dictionary<string,string> param)
        {
            OracleConnection con = null;
            try
            {
                con = GetOracleCon();
                OracleCommand command = new OracleCommand(proName, con);
                command.CommandType = CommandType.StoredProcedure;
                foreach (string item in param.Keys)
                {
                    
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteQuerySqlServer(string text)
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlServerCon();
                SqlDataAdapter adapter = new SqlDataAdapter(text, con);
                DataTable table = new DataTable("result");
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static void ExecuteNonQuerySqlServer(string text)
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlServerCon();
                SqlCommand command = con.CreateCommand();
                command.CommandText = text;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static void ExecuteNonQuerySqlServer(List<string> list)
        {
            SqlConnection con = null;
            SqlTransaction tran = null;
            try
            {
                con = GetSqlServerCon();
                SqlCommand command = con.CreateCommand();
                tran = con.BeginTransaction();
                command.Transaction = tran;
                for (int i = 0; i < list.Count; i++)
                {
                    command.CommandText = list[i];
                    command.ExecuteNonQuery();
                }
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static DataTable ExecuteQuerySqlServer(string text, SqlConnection con)
        {

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(text, con);
                DataTable table = new DataTable("result");
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseCon(con);
            }
        }

        public static object ExecuteScalarSqlServer(string text)
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlServerCon();
                SqlCommand command = new SqlCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static object ExecuteScalarOracle(string text, SqlConnection con)
        {
            try
            {
                SqlCommand command = new SqlCommand(text, con);
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
