/* 
 * Programmer: Baran Topal                       *
 * Solution name: RestService                    * 
 * Project name: TestRest                        *
 * File name: TestRest.cs                        *
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
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Company;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRest
{
    [TestClass]
    public class TestRest
    {
        [TestMethod]
        public void ConnectionTest()
        {
            var employee = new Employee(); ;
            string strConnString = "Server=127.0.0.1;Database=Company;User Id=sa; Password=sa;";
            var dal = new Dal(strConnString);

            SelectCommand(employee, dal);
        }

        [TestMethod]
        public void GETTest()
        {
            GenerateGetRequest();
        }

        [TestMethod]
        public void POSTTest()
        {
            GeneratePostRequest();
        }

        public void SelectCommand(Employee employee, Dal dal)
        {
            dal.GetEmployees();
            Console.WriteLine("Testing Select command");
            employee = dal.GetEmployee(3550);
            PrintEmployeeInformation(employee);
        }

        private static void PrintEmployeeInformation(Employee emp)
        {
            Console.WriteLine("Emplyee Id - {0}", emp.Id);
            Console.WriteLine("Employee Name - {0}", emp.Name);
            Console.WriteLine("Employee Age  - {0}", emp.Age);
            Console.WriteLine("Employee Type - {0}", emp.Type);
        }

        private static void GenerateGetRequest()
        {

            //Generate get request
            string url = "http://localhost/RestService/employee?id=3550";
            var GETRequest = (HttpWebRequest)WebRequest.Create(url);
            GETRequest.Method = "GET";

            Console.WriteLine("Sending GET Request");
            var getResponse = (HttpWebResponse)GETRequest.GetResponse();
            var getResponseStream = getResponse.GetResponseStream();
            var sr = new StreamReader(getResponseStream);

            Console.WriteLine("Response from Server");
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadLine();
        }

        private static void GeneratePostRequest()
        {

            try
            {
                Console.WriteLine("Testing POST Request");
                var strURL = "http://localhost/RestService/employee";
                var name = "Vero";
                var id = 1232;
                var age = 45;
                var type = "permanent";

                byte[] dataByte = GenerateXMLEmployee(name, id, age, type);

                HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(strURL);
                
                POSTRequest.Method = "POST";
                
                POSTRequest.ContentType = "text/xml";
                POSTRequest.KeepAlive = false;
                POSTRequest.Timeout = 5000;
                
                POSTRequest.ContentLength = dataByte.Length;

                
                Stream POSTstream = POSTRequest.GetRequestStream();
                
                POSTstream.Write(dataByte, 0, dataByte.Length);

                //Get response from server
                HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
                StreamReader reader = new StreamReader(POSTResponse.GetResponseStream(), Encoding.UTF8);
                Console.WriteLine("Response");
                Console.WriteLine(reader.ReadToEnd().ToString());
            }
            // this exception is inevitable..but still works out
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                                      .ReadToEnd();
            }
        }

        private static byte[] GenerateXMLEmployee(string name, int id, int age, string type)
        {
            // Create the xml document in a memory stream
            var mStream = new MemoryStream();
            
            var xmlWriter = new XmlTextWriter(mStream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Employee");
            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteString(name);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Id");
            xmlWriter.WriteValue(id);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Age");
            xmlWriter.WriteValue(age);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Type");
            xmlWriter.WriteString(type);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
            return mStream.ToArray();
        }
    }
}
