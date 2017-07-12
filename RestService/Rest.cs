/* 
 * Programmer: Baran Topal                       *
 * Solution name: RestService                    * 
 * Project name: RestService                     *
 * File name: Rest.cs                            *
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
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Company;
using DAL;

namespace RestService
{
    public class Rest : IHttpHandler
    {
        private Dal _dal;
        private Employee employee;
        public void ProcessRequest(HttpContext context)
        {
            var url = Convert.ToString(context.Request.Url);

            string _connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            _dal = new Dal(_connString);

            if (context.Request.HttpMethod == "GET")
            {
                Get(context);
            }
            else if (context.Request.HttpMethod == "POST")
            {
                Post(context);
            }
        }

        public void Get(HttpContext context)
        {
            _dal.GetEmployees();
            int employeeId = Convert.ToInt16(context.Request["id"]);
            employee = _dal.GetEmployee(employeeId);

            if (employee == null)
            {
                context.Response.Write("No employee with " + employeeId);
            }
            Serialize(employee, context);
        }

        private void Serialize(Employee employee, HttpContext context)
        {

            var xs = new XmlSerializer(typeof(Company.Employee));
            var memoryStream = new MemoryStream();

            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(memoryStream, employee);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

            Byte[] characters = memoryStream.ToArray();
            var encoding = new UTF8Encoding();
            string constructed = encoding.GetString(characters);

            context.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(constructed);
        }

        public void Post(HttpContext context)
        {
            byte[] postData = context.Request.BinaryRead(context.Request.ContentLength);

            Employee emp = Deserialize(postData);
            _dal.AddEmployee(emp);
        }

        public Employee Deserialize(byte[] postData)
        {
            var ds = new XmlSerializer(typeof(Company.Employee));
            var memoryStream = new MemoryStream(postData);
            var employee = new Employee();
            employee = (Employee)ds.Deserialize(memoryStream);

            return employee;
        }
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
