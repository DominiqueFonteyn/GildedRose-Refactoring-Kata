using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const int MaxItemQuality = 50;

    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePassesToATafkal80EtcConcert)
            {
                if (item.Quality > 0)
                {
                    if (IsNotLegendaryItem(item))
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < MaxItemQuality)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < MaxItemQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < MaxItemQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
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
                        if (item.Quality > 0)
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

    private static bool IsNotLegendaryItem(Item item)
    {
        return item.Name != SulfurasHandOfRagnaros;
    }
}