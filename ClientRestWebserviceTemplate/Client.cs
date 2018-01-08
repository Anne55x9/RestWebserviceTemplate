using RestWebserviceTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ClientRestWebserviceTemplate
{
    internal class Client
    {
        private const string uri = "http://localhost:51165/Service1.svc";

        public Client()
        {
            
        }

        public void StartClient()
        {
            // Henter alle XX i liste.
            var XXesList = GetAllXXAsync().Result;
            Console.WriteLine("Alle xx: \n ");

            foreach (var x in XXesList)
            {
                Console.WriteLine("Id: " + x.Id + "Navn: " + x.Navn + "X1: " + x.X1 + "X2: " + x.X2 + "X3: " + x.X3 + "X4: " + x.X4);
            }



            //Henter en XX ud fra Id
            var oneXX = GetXXByIdAsync("1").Result;
            Console.WriteLine("En XX med Id 1: " + oneXX.Id + "\n" + "Navn:" + oneXX.Navn + "X1:" + oneXX.X1 + "X2:" + oneXX.X2 + "X3:" + oneXX.X3 + "X4:" + oneXX.X4);


            //Poster nyt element i liste.

            PostXXAsync(new ClassName()
            {
                Navn = "C",
                X1 = "C",
                X2 = 9.9,
                X3 = "C",
                X4 = 12
            });


            var newlistAfterPost = GetAllXXAsync().Result;
            Console.WriteLine("Alle elementer efter post \n");
           

            foreach (ClassName x in newlistAfterPost)
            {
                Console.WriteLine("Navn: " + x.Navn + " X1: " + "" + x.X1 + "" + " X2: " + x.X2 + " X3: " + x.X3 + "" + " X4: " + x.X4);
            }


            //Slette et element ud fra id

            //var deleteEle = DeleteXXAsync("3").Result;
            //Console.WriteLine("Element nr =" + deleteEle.Id + " er slettet \n" + "Navn:" + deleteEle.Navn + "X1:" + deleteEle.X1 + "X2:" + deleteEle.X2 + "X3:" + deleteEle.X3 + "X4:" + deleteEle.X4);

            //Console.WriteLine("Alle elementer efter delete \n");
            var newlistAfterDelete = GetAllXXAsync().Result;

            //foreach (ClassName x in newlistAfterDelete)
            //{
            //    Console.WriteLine("Navn: " + x.Navn + " X1: " + "" + x.X1 + "" + " X2: " + x.X2 + " X3: " + x.X3 + "" + " X4: " + x.X4);
            //}


            //Poster nyt element i liste.

            PutXXAsync("1", new ClassName()
            {
                Navn = "C",
                X1 = "C",
                X2 = 9.9,
                X3 = "C",
                X4 = 12
            });


            var newlistAfterPut = GetAllXXAsync().Result;
            Console.WriteLine("Alle elementer efter put \n");


            foreach (ClassName x in newlistAfterPut)
            {
                Console.WriteLine("Navn: " + x.Navn + " X1: " + "" + x.X1 + "" + " X2: " + x.X2 + " X3: " + x.X3 + "" + " X4: " + x.X4);
            }

        }



        //Alle XXes

        private static async Task<IList<ClassName>> GetAllXXAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/XXes");
                IList<ClassName> xList = JsonConvert.DeserializeObject<IList<ClassName>>(content);
                return xList;
            }
          
        }


        private static async Task<ClassName> GetXXByIdAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/XX/" + id);
                ClassName xList = JsonConvert.DeserializeObject<ClassName>(content);
                return xList;
            }
        }


       

        private static async Task<ClassName> PostXXAsync(ClassName newFangst)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newFangst));
                content.Headers.ContentType = new MediaTypeHeaderValue("Application/json");

                var result = await client.PostAsync(uri + "/XXes", content);
                ClassName x = JsonConvert.DeserializeObject<ClassName>(result.Content.ReadAsStringAsync().Result);
                return x;
            }
        }

        private static async Task<ClassName> PutXXAsync(string id,ClassName updateFangst)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(updateFangst));
                content.Headers.ContentType = new MediaTypeHeaderValue("Application/json");

                var result = await client.PutAsync(uri + "/XXes/" + id, content);
                ClassName x = JsonConvert.DeserializeObject<ClassName>(result.Content.ReadAsStringAsync().Result);
                return x;
            }
        }

        private static async Task<ClassName> DeleteXXAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.DeleteAsync(uri + "/XXes/" + id);
                ClassName c = JsonConvert.DeserializeObject<ClassName>(content.Content.ReadAsStringAsync().Result);
                return c;
            }
        }
    }
}
