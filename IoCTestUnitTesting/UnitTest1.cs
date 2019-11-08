using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCTest;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace IoCTestUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IEmployee> FakeDataAccess;
        EmployeeBusinessLogic EBL;

        [TestInitialize]
        public void Setup()
        {
            var fakeList = new List<string>() { "55000", "45000", "35000" };
            FakeDataAccess = new Mock<IEmployee>();
            FakeDataAccess.Setup(e => e.GetEmployeeSalary(It.IsAny<int>())).Returns(55000);
            FakeDataAccess.Setup(i => i.GetTop3Salarys()).Returns(fakeList.ToString());
            FakeDataAccess.Setup(x => x.GetHiringDate(It.IsAny<int>())).Returns(3);

            EBL = new EmployeeBusinessLogic(FakeDataAccess.Object);
        }
        [TestMethod]
        public void CheckForEmployeeSalary_Test()
        {
            var getSalary = EBL.handleEmployeeSalary(5);
            Assert.AreEqual(getSalary, "55000");
        }
        [TestMethod]
        public void GetTop3Employees_Test()
        {
            var getTop3 = EBL.handleTop3EmployeeSalarys();
            Assert.AreEqual(getTop3, new List<string>() { "55000", "45000", "35000" }.ToString());
        }
        [TestMethod]
        public void GetEmployeeBonus_Test()
        {
            var bonus = EBL.calculateBonus(3);
            Assert.AreEqual(bonus, 1650);
        }
    }
}
