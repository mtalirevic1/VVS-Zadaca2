using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Zadaca2a;
using Zadaca2a.Klase;
using Assert = NUnit.Framework.Assert;


namespace TestProject
{
    public class CentralaTest
    {
        private Centrala centrala;
        private Sekretarica sekretarica, sekretarica2, sekretarica3;
        private Korisnik korisnik, korisnik2, korisnik3;
        private Poruka poruka;
        private List<Korisnik> primaoci;

        [SetUp]
        public void Init()
        {
            korisnik = new Korisnik("Matej", "Talirevic", "999999", new DateTime(1998, 2, 25), "0", 1000);
            korisnik2 = new Korisnik("Kerim", "Kadusic", "999888", new DateTime(1999, 6, 12), "0", 1000);
            korisnik3 = new Korisnik("Lino", "Bevanda", "777888", new DateTime(1998, 7, 20), "0", 1000);
            centrala = new Centrala("PrvaCentrala");
            sekretarica = new Sekretarica(korisnik);
            sekretarica2 = new Sekretarica(korisnik2);
            sekretarica3 = new Sekretarica(korisnik3);
            centrala.registrujSekretaricu(sekretarica);
            centrala.registrujSekretaricu(sekretarica2);
            centrala.registrujSekretaricu(sekretarica3);
            primaoci = new List<Korisnik>();
            primaoci.Add(korisnik2);
            primaoci.Add(korisnik3);
            poruka = new Poruka("Ovo je poruka.", DateTime.Now, korisnik, primaoci);
        }

        //testovi za metodu registrujSekretaricu
        
        //TDD test metoda
        
        /*private TestContext testContextInstance;

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
             "|DataDirectory|\\CSVData.csv", "CSVData#csv",
             DataAccessMethod.Sequential), DeploymentItem("CSVData.csv"), TestMethod]
        public void registrujSekretaricuCSV()
        {
            Korisnik k=new Korisnik(Convert.ToString(TestContext.DataRow["ime"]),Convert.ToString(TestContext.DataRow["prezime"]),
                Convert.ToString(TestContext.DataRow["brojTelefona"])); //treba ovo napraviti da radi i dopuniti
            Sekretarica sekretarica=new Sekretarica(k);
            Boolean result = centrala.registrujSekretaricu(sekretarica);
            Assert.True(result);
        }*/

        [Test]
        public void registrujSekretaricuBasicTest()
        {
            Boolean result = centrala.registrujSekretaricu(sekretarica);
            Assert.False(result);
        }

        [Test]
        public void registrujSekretaricuBasicTest2()
        {
            Sekretarica sekretarica2 = new Sekretarica(korisnik2);
            centrala.registrujSekretaricu(sekretarica);
            Boolean result = centrala.registrujSekretaricu(sekretarica2);
            Assert.False(result);
        }

        [Test]
        public void registrujSekretaricuIstiKorisnikTest()
        {
            korisnik2 = korisnik;
            Sekretarica sekretarica2 = new Sekretarica(korisnik2);
            centrala.registrujSekretaricu(sekretarica);
            Boolean result = centrala.registrujSekretaricu(sekretarica2);
            Assert.False(result);
        }

        //testovi za metodu posaljiPoruku
        [Test]
        public void posaljiPorukuBasicTest()
        {
            List<Korisnik> result = centrala.posaljiPoruku(poruka);
            Assert.IsEmpty(result);
        }

        [Test]
        public void posaljiPorukuNeuspjelaTest()
        {
            primaoci.Add(new Korisnik("Neko", "Nekic", "1", DateTime.Now, "0", 1000));
            List<Korisnik> result = centrala.posaljiPoruku(poruka);
            Assert.AreEqual(result.Count, 1);
        }
    }
}