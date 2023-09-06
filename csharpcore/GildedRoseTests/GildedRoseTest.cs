using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void ItemQuality_ItemIsAgedBrie_ShouldNeverBeMoreThanFifty()
    {
        const int initialQuality = 50;
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = initialQuality } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(initialQuality, items[0].Quality);
    }

    [Fact]
    public void ItemQuality_BackstagePasses_ShouldNeverBeMoreThanFifty()
    {
        const int initialQuality = 50;
        IList<Item> items = new List<Item>
            { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = initialQuality } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(initialQuality, items[0].Quality);
    }

    [Fact]
    public void ItemQuality_BackstagePassesSellInLowerThan6_QualityIncreasesByThree()
    {
        const int initialQuality = 10;
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = initialQuality }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.Equal(initialQuality + 3, items[0].Quality);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void ItemQuality_BackstagePassesSellInHigherThan5AndLowerThan11_QualityIncreasesByTwo(int sellIn)
    {
        const int initialQuality = 10;
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.Equal(initialQuality + 2, items[0].Quality);
    }

    [Fact]
    public void ItemQuality_SomeItem_QualityDecreasesByOne()
    {
        const int initialQuality = 10;
        var items = new List<Item>
        {
            new Item { Name = "SomeItem", SellIn = 5, Quality = initialQuality }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.Equal(initialQuality - 1, items[0].Quality);
    }
}