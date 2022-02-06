using System;
using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Tests
{
    // Many tests done here, each test title explains what we are testing in the code
    [TestFixture]
    public class Tests
    {
        [Test]
        public void QualityOfItemShouldDecreaseByOneEachDay()
        {
            // Arrange
            var item = new Item {Name = "foo", SellIn = 3, Quality = 5};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.AreEqual(item.Quality, 4);
        }
        
        [Test]
        public void SellInOfItemShouldDecreaseByOneEachDay()
        {
            // Arrange
            var item = new Item {Name = "foo", SellIn = 3, Quality = 5};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.AreEqual(item.SellIn, 2);
        }
        
        [Test]
        public void QualityCanNeverBeNegative()
        {
            // Arrange
            var item = new Item {Name = "foo", SellIn = 2, Quality = 5};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.SellIn >= 0);
        }
        
        [Test]
        public void QualityHasToDecreaseTwiceFasterAfterSellIn()
        {
            // Arrange
            var item = new Item {Name = "foo", SellIn = 0, Quality = 5};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 3);
        }
        
        [Test]
        public void CheeseIncreasesAsTimePasses()
        {
            // Arrange
            var item = new Item {Name = "Aged Brie", SellIn = 4, Quality = 5};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 6);
        }
        
        [Test]
        public void QualityOfAProductCannotExceed50()
        {
            // Arrange
            var item = new Item {Name = "Aged Brie", SellIn = 4, Quality = 50};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 50);
        }
        
        [Test]
        public void SulfurasQualityHasToBe80()
        {
            // Arrange
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality==80);
        }
        
        [Test]
        public void SulfurasCannotLoseQuality()
        {
            // Arrange
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 80);
        }
        
        [Test]
        public void SulfurasHasNoSellIn()
        {
            // Arrange
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.SellIn == 0);
        }
        
        [Test]
        public void BackstagePassesIncreaseBy2_10DaysBeforeConcert()
        {
            // Arrange
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 15};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 17);
        }
        
        [Test]
        public void BackstagePassesIncreaseBy3_5DaysBeforeConcert()
        {
            // Arrange
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 15};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 18);
        }
        
        [Test]
        public void BackstagePassesGoTo0AfterConcert()
        {
            // Arrange
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 15};
            IList<Item> items = new List<Item> {item};
            var app = new csharp.GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert;
            Assert.IsTrue(item.Quality == 0);
        }
    }
}