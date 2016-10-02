using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EARS.Utilities
{
    public static class DBUtlities
    {

        public static void ConnectReportingServer()
        {
            //SQL Connection String
            Settings.ReportingConnString = ConfigurationManager.ConnectionStrings["ReportingConnectionString"].ConnectionString;
            //Create DB Connection
            Settings.ReportingConn = Settings.ReportingConn.DBConnect(Settings.ReportingConnString);
        }

        public static DataSet PopulateDataSet(this SqlConnection Connection, string query)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            try
            {

                command = new SqlCommand(query, Connection);
                command.CommandType = CommandType.Text;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }

            catch (Exception e)
            {
                command = null;
                adapter = null;
                data = null;
                return null;
            }
            finally
            {
                command = null;
                adapter = null;
                data = null;
            }

        }


        //Open the connection
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR :: " + e.Message);
            }

            return null;
        }



        //Closing the connection 
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR :: " + e.Message);
            }
        }


        //Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                //Checking the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();
                System.Console.WriteLine("Query to be executed :" + queryString);
                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                Console.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }
        }

        /// <summary>
        /// Execute Stored Procedure with the Parameters passed
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="procname"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteProcWithParamsDT(this SqlConnection Conn, string procname, Hashtable parameters)
        {
            DataSet dataSet;
            try
            {
                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(procname, Conn);
                dataAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (DictionaryEntry de in parameters)
                    {
                        SqlParameter sp = null;
                        sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());
                        dataAdaptor.SelectCommand.Parameters.Add(sp);
                    }

                dataSet = new DataSet();
                dataAdaptor.Fill(dataSet, "table");
                Conn.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception e)
            {
                dataSet = null;
                Conn.Close();
                Console.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                Conn.Close();
                dataSet = null;
            }
        }

    }
}