using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginPage01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage01.Tests
{
    [TestClass()]
    public class CreateMileageTests
    {
        [TestMethod()]
        public void mileageAlert()
        {
            //test value 
            int currentMileage = 15000;
            int allowedMileage = 7000;


            //running function
            CreateMileage mileageForm = new CreateMileage();
            bool result = mileageForm.compareMileageLimit(currentMileage, allowedMileage);

            //expected result to have a pop up alert
            Assert.AreEqual(true, result, "Success");
        }

        [TestMethod()]
        public void changePassword()
        {
            string name = "Test User";
            string passwordHash = "e16b2ab8d12314bf4efbd6203906ea6c";

            Admin admin = new Admin("E1000", "User", false);

            EditAccount editAcc = new EditAccount(admin);
            

            Assert.IsTrue(editAcc.changePassword(passwordHash, name));
        }

        [TestMethod()]
        public void createBus()
        {
            //test might fail because of null object call in the function.
            //Solution: remove the program.admin.getEmpID() and retest the test case
            string numPlate = "JKM5520";
            string category = "Express Bus";
            string spec = "Luxury bus with 25 seats at air cond at each seat";
            string permit = "P0052";
            string validDate = "25/02/2020-25/02/2022";
            string ownerIc = "990102065522";
            string status = "Available";

            CreateBus bus = new CreateBus();
            bool success = bus.createBus(numPlate, category, spec, permit, validDate, ownerIc, status);

            Assert.AreEqual(true, success, "Success");
        }
    }
}