using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void ItemQuality_ItemIsAgedBrie_ShouldNeverBeMoreThanFifty()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.True(50 >= items[0].Quality);
    }

    [Fact]
    public void ItemQuality_BackstagePasses_ShouldNeverBeMoreThanFifty()
    {
        IList<Item> items = new List<Item>
            { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.True(50 >= items[0].Quality);
    }

    [Fact]
    public void ItemQuality_BackstagePassesSellInLowerThan6_QualityIncreasesByThree()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.Equal(13, items[0].Quality);
    }
}