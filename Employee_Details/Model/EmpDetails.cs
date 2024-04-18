using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Details.Model
{
    
    public class EmpDetails
    {

        [PrimaryKey, AutoIncrement]
        public int id { set; get; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public string password { get; set; }

        public EmpDetails()
        {

        }
        public EmpDetails(string firstname,string lastname,string email,string moblieno,string password)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.mobileno = moblieno;
            this.password = password;

        }

    }
}
