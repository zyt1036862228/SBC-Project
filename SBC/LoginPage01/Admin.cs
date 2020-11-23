using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage01
{
    public class Admin
    {
        private string empID;
        private string name;
        private Boolean master;
        public Admin(string empID, string name, Boolean master)
        {
            this.empID = empID;
            this.name = name;
            this.master = master;
        }

        public String getEmpID() { return this.empID; }
        public String getName() { return this.name; }
        public Boolean getMaster() { return this.master; }
    }
}
