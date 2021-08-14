using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestAdoDotNetConnection.Models;
using TestAdoDotNetConnection.Utilities;

namespace TestAdoDotNetConnection.DAL
{
    public class Repository<T> where T:new()
    {
        public string ConnectionString { get; set; }
        public Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<T> GetAll(string tableName)
        {
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // Create the command  
                SqlCommand command = new SqlCommand("SELECT * FROM " + (string.IsNullOrWhiteSpace(tableName) ? typeof(T).Name : tableName), conn);


                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    // create the DataSet 
                    DataSet dataSet = new DataSet();
                    // fill the DataSet using our DataAdapter 
                    dataAdapter.Fill(dataSet);

                    var list = dataSet.Tables[0].AsEnumerable()
                        .Select(dataRow => dataRow.ToObject<T>()).ToList();
                    return list;
                }
            }
        }
    }
}