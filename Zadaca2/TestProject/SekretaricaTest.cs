using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Zadaca2a;
using Zadaca2a.Klase;
using Zadaca2a.Izuzeci;
using Assert = NUnit.Framework.Assert;
using StringAssert = NUnit.Framework.StringAssert;

namespace TestProject
{
    public class SekretaricaTest
    {
        private Sekretarica sekretarica;
        private Korisnik korisnik;

        [SetUp]
        public void Init()
        {
            korisnik = new Korisnik("Matej", "Talirevic", "999999", new DateTime(1998, 2, 25), "0", 1000);
            sekretarica = new Sekretarica(korisnik);
        }

        // Testovi za metodu povecajKapacitet
        [Test]
        public void KapacitetTestCase1()
        {
            string rezultat1 = sekretarica.povecajKapacitet(19);
            StringAssert.AreEqualIgnoringCase(rezultat1,
                "Kapacitet uspješno povećan sa 2 na 21 poruka, a to vas je koštalo =29.45 KM.");
        }

        [Test]
        public void KapacitetTestCase2()
        {
            string rezultat2 = sekretarica.povecajKapacitet(22);
            StringAssert.AreEqualIgnoringCase(rezultat2,
                "Kapacitet uspješno povećan sa 2 na 24 poruka, a to vas je koštalo =32.395 KM.");
        }

        [Test]
        public void KapacitetTestCase3()
        {
            string rezultat3 = sekretarica.povecajKapacitet(55);
            StringAssert.AreEqualIgnoringCase(rezultat3,
                "Kapacitet uspješno povećan sa 2 na 57 poruka, a to vas je koštalo =76.725 KM.");
        }

        [Test]
        public void PovecajKapacitetTest1()
        {
            Assert.Throws<Exception>(() => sekretarica.povecajKapacitet(-20));
        }

        [Test]
        public void PrimiPorukuTest1()
        {
            Poruka p1, p2;
            var p3 = p1 = p2 = new Poruka("", DateTime.Now, korisnik, null);
            sekretarica.Algoritam = "SecondChance";
            sekretarica.primiPoruku(p1);
            sekretarica.primiPoruku(p2);
            Assert.Throws<AlgorithmNotValidException>(() => { sekretarica.primiPoruku(p3); });
        }

        [Test]
        public void PrimiPorukuTest2()
        {
            Poruka p1, p2;
            var p3 = p1 = p2 = new Poruka("", DateTime.Now, korisnik, null);
            sekretarica.Algoritam = "FIFO";
            sekretarica.primiPoruku(p1);
            sekretarica.primiPoruku(p2);
            Assert.True(sekretarica.primiPoruku(p3));
        }


        //Provjera izuzetaka 
        [Test]
        public void SpremiPoslanuPorukuExcTest1()
        {
            sekretarica = new Sekretarica(korisnik);
            sekretarica.Algoritam = "NOTFIFO";
            Assert.Throws<AlgorithmNotValidException>(() =>
            {
                while (true) sekretarica.spremiPoslanuPoruku(new Poruka("nope", DateTime.Now, null, null));
            });
        }

        [Test]
        public void SpremiPoslanuPorukuExcTest2()
        {
            sekretarica.Algoritam = "NOTFIFO";
            Assert.Throws<AlgorithmNotValidException>(() =>
            {
                while (true) sekretarica.spremiPoslanuPoruku(new Poruka("nope", DateTime.Now, null, null));
            });
        }


        [Test]
        public void ArhivirajPorukuExcTest2()
        {
            Assert.Throws<Exception>(() => { sekretarica.arhivirajPoruke(null, "Nepoznata metoda"); });
        }

        [Test]
        public void FIFOTest1()
        {
            sekretarica.Algoritam = "FIFO";
            List<Poruka> poruke = new List<Poruka>();
            for (int i = 0; i < 10; i++)
            {
                Poruka p = new Poruka("", new DateTime(2019, 10, i + 1), null, null);
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsFalse(sekretarica.PristiglePoruke.Contains(poruke[5])
                           && sekretarica.PristiglePoruke.Contains(poruke[2]));
        }


        [Test]
        public void LIFOTest1()
        {
            sekretarica.Algoritam = "LIFO";
            List<Poruka> poruke = new List<Poruka>();
            for (int i = 0; i < 10; i++)
            {
                Poruka p = new Poruka("", new DateTime(2019, 10, i + 1), null, null);
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsFalse(sekretarica.PristiglePoruke.Contains(poruke[9]));
        }


        [Test]
        public void PATest1()
        {
            sekretarica.Algoritam = "PA";
            List<Poruka> poruke = new List<Poruka>();
            for (int i = 0; i < 7; i++)
            {
                Poruka p = new Poruka("", new DateTime(2019, 10, i + 1), null, null);
                p.Prioritet = i + 1;
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsTrue(sekretarica.PristiglePoruke.Contains(poruke[5])
                          && sekretarica.PristiglePoruke.Contains(poruke[6]));
        }


        [Test]
        public void PATest2()
        {
            sekretarica.Algoritam = "PA";
            List<Poruka> poruke = new List<Poruka>();
            for (int i = 0; i < 7; i++)
            {
                Poruka p = new Poruka("", new DateTime(2019, 10, i + 1), null, null);
                p.Prioritet = 1;
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsTrue(sekretarica.PristiglePoruke.Contains(poruke[5])
                          && sekretarica.PristiglePoruke.Contains(poruke[6]));
        }

        [Test]
        public void PATest4()
        {
            sekretarica.Algoritam = "PA";
            List<Poruka> poruke = new List<Poruka>();
            for (int i = 0; i < 7; i++)
            {
                Poruka p = new Poruka("", new DateTime(2019, 10, i + 1), null, null);
                p.Prioritet = 10 - i;
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsTrue(sekretarica.PristiglePoruke.Contains(poruke[0]));
        }


        //Zamjenski objekat fake za svrhu testiranja prioritetnog algoritma
        public class Fake : Poruka
        {
            private static int priority = 0;

            public int prioritet()
            {
                Prioritet = ++priority;
                return Prioritet;
            }

            public Fake() : base("", System.DateTime.Now, null, null)
            {
            }

            public Fake(string tekstPoruke, DateTime datumSlanja, Korisnik posiljaoc, List<Korisnik> primaoci) : base(
                tekstPoruke, datumSlanja, posiljaoc, primaoci)
            {
            }
        }

        [Test]
        public void PATestSpy() //test sa zamjenskim objektom
        {
            sekretarica.Algoritam = "PA";
            List<Fake> poruke = new List<Fake>();
            for (int i = 0; i < 7; i++)
            {
                Fake p = new Fake();
                p.prioritet();
                sekretarica.primiPoruku(p);
                poruke.Add(p);
            }

            Assert.IsTrue(sekretarica.PristiglePoruke.Contains(poruke[5])
                          && sekretarica.PristiglePoruke.Contains(poruke[6]));
        }
    }
}