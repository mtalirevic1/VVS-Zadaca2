using System;
using Zadaca2a.Izuzeci;
using Zadaca2a.Klase;
using NUnit.Framework;

namespace TestProject
{
    class KarticaTest
    {
        Kartica k = null;

        [SetUp]
        public void Init()
        {
            k = new Kartica("4012888888881881", 1000);
        }

        //Ovaj test provjerava ekstremne slucajeve
        [Test]
        public void NeispravanBrojKarticeTest1()
        {
            Assert.IsFalse(k.validirajBrojkartice(""));
        }

        //Neispravni brojevi (jos uvijek ekstreman slucaj)
        [Test]
        public void NeispravanBrojKarticeTest2()
        {
            Assert.IsFalse(k.validirajBrojkartice("2.2255"));
        }

        //Kad sumaCifara%10!=0
        [Test]
        public void NeispravanBrojKarticeTest3()
        {
            Assert.IsFalse(k.validirajBrojkartice("372948467675726"));
        }

        public void NeispravanBrojKarticeTest4()
        {
            Assert.IsFalse(k.validirajBrojkartice("nekaSlova"));
        }

        public void NegativanBrojKarticeTest()
        {
            Assert.IsFalse(k.validirajBrojkartice("-4012888888881881"));
        }

        [Test]
        public void IspravanBrojKarticeTest()
        {
            Assert.IsTrue(k.validirajBrojkartice("4012888888881881"));
        }

        [Test]
        public void ValidirajSlovaTest1()
        {
            Assert.IsFalse(Kartica.validirajSlova("123423+*"));
        }

        //provjera za prazan string
        [Test]
        public void ValidirajSlovaTest2()
        {
            Assert.IsFalse(Kartica.validirajSlova(""));
        }

        [Test]
        public void ValidirajSlovaTest3()
        {
            Assert.IsFalse(Kartica.validirajSlova("echo123---"));
        }

        [Test]
        public void ValidirajSlovaTest4()
        {
            Assert.IsTrue(Kartica.validirajSlova("KoMbiNaCiJa"));
        }

        //provjera izuzetaka
        [Test]
        public void CreditCardNotValidExcTest()
        {
            Assert.Throws<CreditCardNotValidException>(() => { k.BrojKreditneKartice = "nebroj"; });
        }

        public void CreditCardNotValidExcTest1()
        {
            Assert.Throws<CreditCardNotValidException>(() => { k.Stanje = -1000; });
        }

        [Test]
        public void NotEnoughMoneyExcTest()
        {
            k.Stanje = 10;
            Assert.Throws<NotEnoughMoneyException>(() => { k.naplati(2000); });
        }
    }
}