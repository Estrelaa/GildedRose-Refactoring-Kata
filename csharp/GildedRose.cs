using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    //Do nothing with this item, move on to the next item
                }
                else
                {
                    if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        UpdateQuailtyOfDifferentRulingItems(i);
                    }
                    else
                    {
                        UpdateQuailtyOfNormalItem(i);
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;
                    UpdateQuailtyIfSellInIsZero(i);
                    CheckThetQuailtyLevelIsWithinAllowedValues(i);
                }
            }               
        }

        private void UpdateQuailtyIfSellInIsZero(int i)
        {
            if (Items[i].SellIn >= 0) return;
    
            if (Items[i].Name == "Aged Brie")
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;
                }
            }
            else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                Items[i].Quality = 0;
            }
            else
            {
                if (Items[i].Quality > 0)
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
            }
        }

        private void UpdateQuailtyOfDifferentRulingItems(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;

            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].SellIn < 11)
                {
                    Items[i].Quality = Items[i].Quality + 1;
                }
                if (Items[i].SellIn < 6)
                {
                    Items[i].Quality = Items[i].Quality + 1;
                }
            }
        }

        private void CheckThetQuailtyLevelIsWithinAllowedValues(int i)
        {
            if (Items[i].Quality >= 50)
            {
                Items[i].Quality = 50;
            }
            else if (Items[i].Quality < 0)
            {
                Items[i].Quality = 0;
            }
        }

        private void UpdateQuailtyOfNormalItem(int i)
        {
            if (Items[i].Quality > 0)
            {
                if (Items[i].Name == "Conjured Mana Cake")
                {
                    Items[i].Quality = Items[i].Quality - 2;
                }
                else
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
            }
        }
    }
}
