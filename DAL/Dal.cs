/* 
 * Programmer: Baran Topal                       *
 * Solution name: RestService                    * 
 * Project name: DAL                             *
 * File name: Dal.cs                             *
 *                                               *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Company;

namespace DAL
{

    public class Dal
    {
        private SqlConnection _connection;
        private static string _connectionString;
        private SqlCommand _command;

        private List<Employee> _employees;

        public Dal(string connString)
        {
            _connectionString = connString;
        }

        public Employee GetEmployee(int Id)
        {
            foreach (var employee in _employees)
            {
                if (employee.Id == Id)
                    return employee;
            }
            return null;
        }

        public List<Employee> GetEmployees()
        {
            _employees = new List<Employee>();
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            var selection = "SELECT * FROM Employee";
            _command = new SqlCommand(selection, _connection);

            var reader = _command.ExecuteReader();

            while (reader.Read())
            {
                var employee = new Employee();
                employee.Name = reader[0].ToString();
                employee.Age = Int32.Parse(reader[1].ToString());
                employee.Id = Int32.Parse(reader[2].ToString());
                employee.Type = reader[3].ToString();
                _employees.Add(employee);
            }
            _command.Connection.Close();
            return _employees;
        }

        public void AddEmployee(Employee employee)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            string insertion = "INSERT INTO Employee(Name, Age, Id, Type) VALUES (@name, @age, @id, @type)";
            _command = new SqlCommand(insertion, _connection);

            SqlParameter nameParam = new SqlParameter("@name", employee.Name);
            SqlParameter ageParam = new SqlParameter("@age", employee.Age);
            SqlParameter idParam = new SqlParameter("@id", employee.Id);
            SqlParameter typeParam = new SqlParameter("@type", employee.Type);

            _command.Parameters.AddRange(new SqlParameter[] { nameParam, ageParam, idParam, typeParam });

            _command.ExecuteNonQuery();
            _command.Connection.Close();

        }
    }
}
