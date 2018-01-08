using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestWebserviceTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWebserviceTemplate.Tests
{
    [TestClass()]
    public class ClassNameTests
    {
        [TestMethod()]
        public void GetX4Correct()
        {
            //Arrange

            var xx = new ClassName(99, "Navn", "string", 33, "string", 22);

            //Act 

            int xxActual = xx.GetX4();

            //Assert

            Assert.AreEqual(22,xxActual);
        }

        [TestMethod()]

        [ExpectedException(typeof(ArgumentException))]
        public void GetX4TestForkertAntal()
        {
            //Arrange 

            var test = new ClassName(100,"Navn","string",33,"string",66);

            //Act

            int x4 = test.GetX4();


        }


    }
}