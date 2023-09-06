using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const int MaxItemQuality = 50;
    private const int MinItemQuality = 0;

    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name is AgedBrie or BackstagePassesToATafkal80EtcConcert)
            {
                IncreaseItemQuality(item);
            }
            else
            {
                if (item.Quality > MinItemQuality)
                {
                    if (IsNotLegendaryItem(item))
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }

            if (IsNotLegendaryItem(item))
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.Quality > MinItemQuality)
                        {
                            if (IsNotLegendaryItem(item))
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < MaxItemQuality)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }

    private static void IncreaseItemQuality(Item item)
    {
        if (item.Name != BackstagePassesToATafkal80EtcConcert)
        {
            AlterQuality(item, 1);
            return;
        }
        
        if (item.SellIn < 6)
        {
            AlterQuality(item, 3);
            return;
        }
        
        if (item.SellIn < 11)
        {
            AlterQuality(item, 2);
            return;
        }
        
        AlterQuality(item, 1);
    }

    private static void AlterQuality(Item item, int quality)
    {
        if (item.Quality + quality > 50)
        {
            item.Quality = 50;
            return;
        }

        if (item.Quality + quality < 0)
        {
            item.Quality = 0;
            return;
        }
        
        item.Quality += quality;
    }

    private static bool IsNotLegendaryItem(Item item)
    {
        return item.Name != SulfurasHandOfRagnaros;
    }
}