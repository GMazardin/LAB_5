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
                // I chose to create a switch based on the item name
                // I would have liked to make inheritance, but we couldn't change the "Item.cs" file and I had no idea
                // on how to make it using only "GildedRose.cs"
                switch (Items[i].Name)
                {
                    case "Aged Brie": // Case of the Aged Brie that is different from others
                        Items[i].SellIn -= 1; // Start by decreasing sellin
                        if (Items[i].SellIn >= 0) // If its sellin is 0 or above, its quality has to increase by 1
                        {
                            Items[i].Quality += 1;
                        }
                        else // If sellin is negative, its quality must increase by 2
                        {
                            Items[i].Quality += 2;
                        }
                        
                        if (Items[i].Quality > 50) // Security loop check to avoid 50 or above qualities that must be impossible
                        {
                            Items[i].Quality = 50;
                        }
                        break;
                    
                    case "Sulfuras, Hand of Ragnaros": // Sulfuras has quality of 80 anytime and never changes
                        Items[i].Quality = 80;
                        break;
                    
                    case "Backstage passes to a TAFKAL80ETC concert": // Case of Backstage passes that follow particular rules
                        Items[i].SellIn -= 1; // Start by decreasing sellin
                        
                        // If sellin goes from 10 to 9 and is 5 or above, its quality must increase by 2
                        // I used 9 instead of 10 here because I start be decreasing sellin
                        if (Items[i].SellIn <= 9 && Items[i].SellIn >= 5)
                        {
                            Items[i].Quality += 2;
                        }
                        
                        // If sellin goes from 5 to 4 and is 0 or above, its quality must increase by 3
                        // Same as before, I used 4 instead of 5 because I start by decreasing sellin
                        else if (Items[i].SellIn <= 4 && Items[i].SellIn >= 0)
                        {
                            Items[i].Quality += 3;
                        }
                        
                        // If sellin is 10 or above, then quality only increases by 1
                        else if (Items[i].SellIn >= 10)
                        {
                            Items[i].Quality += 1;
                        }
                        
                        // If sellin is negative, then quality goes to 0 because concert has passed
                        else
                        {
                            Items[i].Quality = 0;
                        }
                        
                        // Security loop check to avoid 50 or above qualities that must be impossible
                        if (Items[i].Quality > 50)
                        {
                            Items[i].Quality = 50;
                        }
                        break;
                    
                    default: // All other objects
                        Items[i].SellIn -= 1; // Start by decreasing sellin
                        
                        // Security loop check to avoid 50 or above qualities that must be impossible
                        if (Items[i].Quality > 50) 
                        {
                            Items[i].Quality = 50;
                        }
                        
                        // If sellin is positive, quality decreases by 1, and if negative it decreases by 2
                        else if (Items[i].Quality < 50 && Items[i].Quality > 0)
                        {
                            if (Items[i].SellIn >= 0)
                            {
                                Items[i].Quality -= 1;
                            }
                            else
                            {
                                Items[i].Quality -= 2;
                            }
                        }

                        // Security loop check to avoid negative qualities that must be impossible
                        if (Items[i].Quality < 0)
                        {
                            Items[i].Quality = 0;
                        }
                        break;
                }
            }
        }
    }
}
