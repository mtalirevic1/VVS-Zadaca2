using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Zadaca2a;
using Zadaca2a.Izuzeci;
using Zadaca2a.Klase;

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
        public void PrioritetExc ()
        {
            Assert.Throws<Exception>(() => {
                p.Prioritet = 21;
               });
            Assert.Throws<Exception>(() => {
                p.Prioritet = -21;
            });
        }


        [Test]
        public void LongMessageExc()
        {
            Assert.Throws<MessageTooLongException>(() => {
                p.TekstPoruke = "Ovo je duza poruka. Ovo je duza poruka. Ovo je duza poruka.";
            });
        }

    }
}
