using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using Zadaca2a;
using Zadaca2a.Izuzeci;
using Zadaca2a.Klase;
using Assert = NUnit.Framework.Assert;

namespace TestProject
{
    class PorukaTest
    {
        Poruka p;

        [SetUp]
        public void Init()
        {
            p = new Poruka("Tekst", DateTime.Now, null, null);
        }

        // Test izuzetaka
        [Test]
        public void PrioritetExcTest()
        {
            Assert.Throws<Exception>(() => { p.Prioritet = 21; });
        }

        [Test]
        public void NegativniPrioritetExcTest()
        {
            Assert.Throws<Exception>(() => { p.Prioritet = -21; });
        }


        [Test]
        public void LongMessageExc()
        {
            Assert.Throws<MessageTooLongException>(() =>
            {
                p.TekstPoruke = "Ovo je duza poruka. Ovo je duza poruka. Ovo je duza poruka.";
            });
        }
    }
}