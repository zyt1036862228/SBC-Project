using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage01
{
    public class Customer
    {
        string phoneNo, name, email, ic;

        public Customer(string phoneNo, string name, string email, string ic)
        {
            this.phoneNo = phoneNo;
            this.name = name;
            this.email = email;
            this.ic = ic;
        }

        public String getPhoneNo() { return phoneNo; }
        public String getName() { return name; }
        public String getEmail() { return email; }
        public String getIC() { return ic; }

    }
}
