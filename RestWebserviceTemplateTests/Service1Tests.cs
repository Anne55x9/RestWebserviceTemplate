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
    public class Service1Tests
    {
        [TestMethod()]
        public void GetXXesTest()
        {


            //Arrange

            IService1 service = new Service1();

            //Act

            IList<ClassName> getAll = service.GetXXes();

            //Assert

            Assert.IsTrue(getAll.Count > 0);
        }

        [TestMethod()]
        public void AddXXTest()
        {

            //Arrange

            IService1 service = new Service1();

            //Act

            IList<ClassName> fangstliste = service.GetXXes();

            int count = fangstliste.Count;

            service.AddXX(new ClassName() { Navn = "Navntest", X1 = "Test", X2 = 44, X3 = "Test", X4 = 66 });

            fangstliste = service.GetXXes();

            int newCount = fangstliste.Count;

            //Assert

            Assert.AreEqual(count + 1, newCount);
        }

        [TestMethod()]
        public void UpdateXXTest()
        {
        
       
            //Arrange
            IService1 update = new Service1();

            //Act
            ClassName x1 = new ClassName() { Navn = "KampBænk2", X1 = "Materialer", X2 = 3, X3 = "498", X4= 33 };
            update.AddXX(x1);
            x1.Navn = "testUpdate";
            ClassName updatedXX = update.UpdateXX(x1.Id.ToString(), x1);


            //Assert
            Assert.AreEqual("testUpdate", updatedXX.Navn);

        }

        [TestMethod()]
        public void DeleteToolTest()
        {
            //Arrange
            IService1 XX = new Service1();

            //Act
            ClassName XXdel = XX.DeleteXX("1");


            //Assert
            Assert.AreEqual(1, XXdel.Id);
            Assert.AreEqual("XXX", XXdel.Navn);

            Assert.IsNull(XX.DeleteXX("100"));

        }

      
    }
}