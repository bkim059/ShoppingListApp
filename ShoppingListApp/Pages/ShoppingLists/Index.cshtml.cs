using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Pages.ShoppingLists
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingListApp.Data.ShoppingListAppContext _context;

        public IndexModel(ShoppingListApp.Data.ShoppingListAppContext context)
        {
            _context = context;
        }

        public IList<ShoppingList> ShoppingList { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchItem { get; set; }

        public SelectList? ShopNames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchShop { get; set; }
        
        public async Task OnGetAsync()
        {            
            IQueryable<string> shopQuery = from shop in _context.ShoppingList
                                           orderby shop.ShopName
                                           select shop.ShopName;
            
            var itemNames = from i in _context.ShoppingList
                            select i;

            if (!string.IsNullOrEmpty(SearchItem))
            {
                itemNames = itemNames.Where(i => i.ItemName.Contains(SearchItem));
            }

            if (!string.IsNullOrEmpty(SearchShop))
            {
                itemNames = itemNames.Where(s => s.ShopName == SearchShop);
            }

            ShopNames = new SelectList(await shopQuery.Distinct().ToListAsync());
            ShoppingList = await itemNames.ToListAsync();
        }
    }
}