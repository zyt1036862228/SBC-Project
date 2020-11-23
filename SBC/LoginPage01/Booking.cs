using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage01
{
    public class Booking
    {
        String numberPlate;
        String category;
        String spec;
        String date;
        String ownerName;
        String assignedTo;
        
        public Booking(String date)
        {
            this.numberPlate = null;
            this.category = null;
            this.spec = null;
            this.date = date;
            this.ownerName = null;
            this.assignedTo = "External";
        }

        public Booking(String numberPlate, String category, String spec, String date, String ownerName)
        {
            this.numberPlate = numberPlate;
            this.category = category;
            this.spec = spec;
            this.date = date;
            this.ownerName = ownerName;
            this.assignedTo = "SBC";
        }

        public String getNumberPlate() { return this.numberPlate; }
        public String getCategory() { return this.category; }
        public String getSpec() { return this.spec; }
        public String getDate() { return this.date; }
        public String getOwnerName() { return this.ownerName; }
        public String getAsignedTo() { return this.assignedTo; }
    }
}
