using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestAdoDotNetConnection.Models;

namespace TestAdoDotNetConnection.DAL
{
    public class People
    {
        public List<Employee> Employess { get; set; }

        public List<Student> Students { get; set; }
    }

    public class GeneralRepository
    {
        public People GetAllPeople()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create the command  
                SqlCommand command = new SqlCommand("SP_GetEmployeesAndStudents", conn);
                command.CommandType = CommandType.StoredProcedure;


                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    // create the DataSet 
                    DataSet dataSet = new DataSet();
                    // fill the DataSet using our DataAdapter 
                    dataAdapter.Fill(dataSet);

                    var employeeList = dataSet.Tables[0].AsEnumerable()
                        .Select(dataRow => new Employee
                        {
                            Id = dataRow.Field<int>("Id"),
                            Name = dataRow.Field<string>("Name"),
                            City = dataRow.Field<string>("City"),
                            Salary = dataRow.Field<int>("Salary")
                        }).ToList();


                    var studentList = dataSet.Tables[1].AsEnumerable()
                        .Select(dataRow => new Student()
                        {
                            Id = dataRow.Field<int>("Id"),
                            Name = dataRow.Field<string>("Name"),
                            City = dataRow.Field<string>("City"),
                            Marks = dataRow.Field<int>("Marks")
                        }).ToList();

                    People p = new People();

                    p.Employess = employeeList;
                    p.Students = studentList;

                    return p;
                }
            }
        }
    }
}