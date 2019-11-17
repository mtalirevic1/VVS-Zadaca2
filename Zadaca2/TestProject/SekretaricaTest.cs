﻿using System;
using NUnit.Framework;
using Zadaca2a;
using Zadaca2a.Klase;


namespace Tests
{
    
    public class SekretaricaTest
    {
        private Sekretarica sekretarica;
        private Korisnik korisnik;
        
        [SetUp]
        public void Init()
        {
            korisnik=new Korisnik("Matej","Talirevic","999999",new DateTime(1998,2,25),"0",1000 );
            sekretarica=new Sekretarica(korisnik);
        }
        //testovi za metodu povecajKapacitet
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
    }
}