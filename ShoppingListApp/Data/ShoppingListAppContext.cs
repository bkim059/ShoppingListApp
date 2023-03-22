using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Models;

namespace ShoppingListApp.Data
{
    public class ShoppingListAppContext : DbContext
    {
        public ShoppingListAppContext (DbContextOptions<ShoppingListAppContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingListApp.Models.ShoppingList> ShoppingList { get; set; } = default!;
    }
}
