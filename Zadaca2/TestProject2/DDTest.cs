using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadaca2a;
using Zadaca2a.Klase;

namespace TestProject2
{
    [TestClass]
    public class DDTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
 "|DataDirectory|\\podaci2.csv", "podaci2#csv", DataAccessMethod.Sequential),
 DeploymentItem("podaci2.csv"), TestMethod]
        public void registrujSekretaricuCSV()
        {
            Centrala c = new Centrala("");
            String ime = Convert.ToString(TestContext.DataRow["ime"]);
            String prezime = Convert.ToString(TestContext.DataRow["prezime"]);
            String brojTelefona = Convert.ToString(TestContext.DataRow["brojTelefona"]);
            String dR = Convert.ToString(TestContext.DataRow["datumRodjenja"]);
            DateTime datumRodjenja = DateTime.Parse(dR);
            String brojKK = Convert.ToString(TestContext.DataRow["brojKK"]);
            Double stanje = Convert.ToDouble(TestContext.DataRow["stanje"]);

            DateTime d = new DateTime();
            Kartica kar = new Kartica();

            Korisnik k = new Korisnik(ime, prezime, brojTelefona, datumRodjenja, brojKK, stanje);
           
            Sekretarica sekretarica = new Sekretarica(k);
            Boolean result = c.registrujSekretaricu(sekretarica);
            Assert.IsTrue(result);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
"|DataDirectory|\\podaci3.xml", "Iterations", DataAccessMethod.Sequential),
DeploymentItem("podaci3.xml"), TestMethod]
        public void testXml()
        {

        }
    }
}
