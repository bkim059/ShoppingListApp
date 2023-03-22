using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;

namespace ShoppingListApp.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ShoppingListAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ShoppingListAppContext>>()))
        {
            if (context == null || context.ShoppingList == null) 
            {
                throw new ArgumentNullException("Null ShoppingListContext");
            }

            if (context.ShoppingList.Any()) 
            {
                return;
            }

            context.ShoppingList.AddRange(
                new ShoppingList
                {
                    ItemName = "Banana",
                    ItemQuantity = 5,
                    ShopName = "New World",
                    DueDate = DateTime.Parse("2023-4-10")
                },

                new ShoppingList
                {
                    ItemName = "Apple",
                    ItemQuantity = 7,
                    ShopName = "New World",
                    DueDate = DateTime.Parse("2023-4-1")
                },

                new ShoppingList
                {
                    ItemName = "T-shirt",
                    ItemQuantity = 1,
                    ShopName = "The Warehouse",
                    DueDate = DateTime.Parse("2023-4-8")
                },

                new ShoppingList
                {
                    ItemName = "Milk",
                    ItemQuantity = 1,
                    ShopName = "Countdown",
                    DueDate = DateTime.Parse("2023-4-20")
                },

                new ShoppingList
                {
                    ItemName = "Shoes",
                    ItemQuantity = 1,
                    ShopName = "North Beach",
                    DueDate = DateTime.Parse("2023-4-3")
                }
            );
            context.SaveChanges();
        }
    }
}
