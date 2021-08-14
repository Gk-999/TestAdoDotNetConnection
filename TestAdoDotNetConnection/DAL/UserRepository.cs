using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestAdoDotNetConnection.Models;

namespace TestAdoDotNetConnection.DAL
{
    public class UserRepository
    {
        public User ValidateUser(string uName,string pass)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create the command  
                SqlCommand command = new SqlCommand($"select* from Users where UserName = '{uName}' and Password = '{pass}'", conn);


                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    // create the DataSet 
                    DataSet dataSet = new DataSet();
                    // fill the DataSet using our DataAdapter 
                    dataAdapter.Fill(dataSet);

                    var user = dataSet.Tables[0].AsEnumerable()
                        .Select(dataRow => new User
                        {
                            Id = dataRow.Field<int>("Id"),
                            Username = dataRow.Field<string>("Username"),
                            Password = dataRow.Field<string>("Password")
                        }).FirstOrDefault();
                    return user;
                }
            }
        }
    }
}