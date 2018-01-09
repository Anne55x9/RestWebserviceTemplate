using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestWebserviceTemplate
{/// <summary>
/// Datacontract på klassen er ikke nødvendig for funktionelt program. Lader til at være nødvendigt 
/// hvis klassen er i interfaset med attribbutter i interfaset som DATAMEMBERS.
/// </summary>
    //[DataContract]
    public class ClassName
    {
        private int id;

        private string navn;

        private string x1;

        private double x2;

        private string x3;

        private int x4;


        /// <summary>
        /// Lav autogeneret id.
        /// </summary>
        //[DataMember]
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Navn
        {
            get => navn;
            set => navn = value;
        }


        public string X1
        {
            get => x1;
            set => x1 = value;
        }


        public double X2
        {
            get => x2;
            set => x2 = value;
        }


        public string X3
        {
            get => x3;
            set
            {
                try
                {
                    x3 = value;
                    GetX3();
                }
                catch (NullReferenceException)
                {
                    value = null;
                    x3 = value;
                    Console.WriteLine("X3 Feltet skal udfyldes!");
                }
            }
        }

        /// <summary>
        /// int med fejlhåndtering ved forkert antal. hvis uger ikke er mellem 1 og 52 begge tal inkluderet.
        /// </summary>
        public int X4
        {
            get => x4;

            set
            {
            //=> x4 = value;

            try
            {
                x4 = value;
                GetX4();
            }

            catch (ArgumentException)
            {
                value = 0;
                x4 = value;
                Console.WriteLine("x4 er mellem 1 og 52!");
            }


            }
        }


        public ClassName() 
            //: this(1, "Dummy", "Dummy2", 11, "Dummy3", 77)
        {
            
        }

        public ClassName(int id, string navn, string x1, double x2, string x3, int x4)
        {
            this.id = id;
            this.navn = navn;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }


        public string GetX3()
        {
            if (X3.Length != 0)
            {
                return X3;
            }
            else
            {
                throw new NullReferenceException("Modellen navnet må ikke være tomt.");
            }
        }

        public int GetX4()
        {
            if(X4 >= 1 && X4 <= 52)
            {
                return X4;
            }
            //else
            {
                throw new ArgumentException("Uger er mellem 1 og 52");
            }
        }



        public override string ToString()
        {
            return "Int: " + Id + "string: " + Navn + "String: " + X1 + " double: " + X2 + " string: " + X3 + "X4: " +
                   X4;

        }
    }
}
