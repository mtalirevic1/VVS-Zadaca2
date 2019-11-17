using System;
using Zadaca2a;
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
        public void NeispravanBrojKarticeTest1 ()
        {
            //
            Assert.IsFalse(k.validirajBrojkartice(""));
            Assert.IsFalse(k.validirajBrojkartice("nekaSlova"));
            Assert.IsFalse(k.validirajBrojkartice("****::"));
        }
        //Neispravni brojevi (jos uvijek ekstreman slucaj)
        [Test]
        public void NeispravanBrojKarticeTest2()
        {
            Assert.IsFalse(k.validirajBrojkartice("1"));
            Assert.IsFalse(k.validirajBrojkartice("2.2255"));
            Assert.IsFalse(k.validirajBrojkartice("-4012888888881881"));
        }
        //Kad sumaCifara%10!=0
        [Test]
        public void NeispravanBrojKarticeTest3()
        {
           Assert.IsFalse(k.validirajBrojkartice("372948467675726"));
           Assert.IsFalse(k.validirajBrojkartice("1315111511125"));
        }

        [Test]
        public void IspravanBrojKarticeTest ()
        {
            Assert.IsTrue(k.validirajBrojkartice("4012888888881881"));
            Assert.IsTrue(k.validirajBrojkartice("6011816573426759"));
        }
        [Test]
        public void ValidirajSlovaTest1 ()
        {
            Assert.IsFalse(Kartica.validirajSlova("123423"));
            Assert.IsFalse(Kartica.validirajSlova("+*"));
         }

        //provjera za prazan string
        [Test]
        public void ValidirajSlovaTest2 ()
        {
            Assert.IsFalse(Kartica.validirajSlova(""));
        }
        [Test]
        public void ValidirajSlovaTest3()
        {
            Assert.IsFalse(Kartica.validirajSlova("echo123"));
            Assert.IsFalse(Kartica.validirajSlova("symbol---"));
        }

        [Test]
        public void ValidirajSlovaTest4()
        {
            Assert.IsTrue(Kartica.validirajSlova("slova"));
            Assert.IsTrue(Kartica.validirajSlova("CAPSLOCK"));
            Assert.IsTrue(Kartica.validirajSlova("KoMbiNaCiJa"));
        }
    }

    
      
}
