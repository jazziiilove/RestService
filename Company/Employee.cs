/* 
 * Programmer: Baran Topal                       *
 * Solution name: RestService                    * 
 * Project name: Company                         *
 * File name: EMployee.cs                        *
 *                                               *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

namespace Company
{
    public class Employee
    {
        private string _name;
        private int _id;
        private int _age;
        private string _type;

        public Employee()
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
