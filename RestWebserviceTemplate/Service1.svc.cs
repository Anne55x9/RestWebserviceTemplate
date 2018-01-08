using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace RestWebserviceTemplate
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static readonly IList<ClassName> XXXList1 = new List<ClassName>();
        private static int nextId = 4;

        static Service1()
        {
            ClassName firstXX = new ClassName()
            {
                Id = 1,
                Navn = "XXX",
                X1 = "XXX",
                X2 = 5.5,
                X3 = "XXX",
                X4 = 1
            
            };

            XXXList1.Add(firstXX);

            ClassName secondXX = new ClassName()
            {
                Id = 2,
                Navn = "YYY",
                X1 = "YYY",
                X2 = 6.6,
                X3 = "YYY",
                X4 = 2

            };

            XXXList1.Add(secondXX);

            ClassName thirdXX = new ClassName()
            {
                Id = 3,
                Navn = "ZZZ",
                X1 = "ZZZ",
                X2 = 7.7,
                X3 = "ZZZ",
                X4 = 10
            };

            XXXList1.Add(thirdXX);

           
        }


        public IList<ClassName> GetXXes()
        {
            return XXXList1;
        }

        public ClassName GetXXById(string id)
        {
            int idNumber = int.Parse(id);
            return XXXList1.FirstOrDefault(xx => xx.Id == idNumber);
        }

        public ClassName AddXX(ClassName newClassNameElement)
        {

                newClassNameElement.Id = nextId++;
                XXXList1.Add(newClassNameElement);
                return newClassNameElement;

            //Json til Fiddler { "Navn":"AAA","X1":"AAA","X2" : 8.8, "X3":"AAA","X4":22}
            //Husk Content-Type:application/json
            //Kør consol app to gange før den kan ses i lister. 
        }

        public ClassName DeleteXX(string id)
        {
           
                ClassName elementToDelete = GetXXById(id);
                if (elementToDelete == null)
                {
                    return null;
                }
                bool removed = XXXList1.Remove(elementToDelete);
                if (removed)
                {
                    return elementToDelete;
                }
                return null;
            
        }

        public ClassName UpdateXX(string id, ClassName updateElement)
        {

                int idNumber = int.Parse(id);
                ClassName existingEle = XXXList1.FirstOrDefault(b => b.Id == idNumber);
                if (existingEle == null)
                {
                    return null;
                }

                existingEle.Navn = updateElement.Navn;
                existingEle.X1 = updateElement.X1;
                existingEle.X2 = updateElement.X2;
                existingEle.X3 = updateElement.X3;
                existingEle.X4 = updateElement.X4;
                return existingEle;

            //Json til Fiddler { "Navn":"Update","X1":"AAA","X2" : 8.8, "X3":"AAA","X4":22}
            //Husk Content-Type:application/json
            //Kør console app 2 gange før kan ses i lister.

        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
