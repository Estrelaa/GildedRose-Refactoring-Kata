using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }
        [Test]
        public void SulfurasQuailtyIsAlways80()
        {
            IList<Item> Items = AddItems.Items();

            var app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    Assert.AreEqual(80, item.Quality);
                }
            }
            
        }
        [Test]
        public void SulfurasSellInDoesNotChange()
        {
            IList<Item> Items = AddItems.Items();

            var app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    //Asuming SellIn is less than 1
                    Assert.LessOrEqual(item.SellIn, 1);
                }
            }

        }
        [Test]
        public void ConjuredManaCakeQualityStaysZeroWhenItReachesZero()
        {
            IList<Item> Items = AddItems.Items();

            var app = new GildedRose(Items);
            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }
            foreach (var item in Items)
            {
                if (item.Name == "Conjured Mana Cake")
                {
                    Assert.AreEqual(0, item.Quality);
                }
            }
        }
        [Test]
        public void ConjuredManaCakeQuailtyLowersBy2PerDay()
        {
            //The test is assuming that the quailty starts at 6
            IList<Item> Items = AddItems.Items();

            var app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                if (item.Name == "Conjured Mana Cake")
                {
                    Assert.AreEqual(4, item.Quality);
                }
            }
        }
        [Test]
        public void AgedBrieIncreasesinQuailtyBy1()
        {
            IList<Item> Items = AddItems.Items();

            var app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie")
                {
                    Assert.AreEqual(1, item.Quality);
                }
            }
        }    
    }
}
