using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Pages.ShoppingLists
{
    public class DeleteModel : PageModel
    {
        private readonly ShoppingListApp.Data.ShoppingListAppContext _context;

        public DeleteModel(ShoppingListApp.Data.ShoppingListAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ShoppingList ShoppingList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShoppingList == null)
            {
                return NotFound();
            }

            var shoppinglist = await _context.ShoppingList.FirstOrDefaultAsync(m => m.Id == id);

            if (shoppinglist == null)
            {
                return NotFound();
            }
            else 
            {
                ShoppingList = shoppinglist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ShoppingList == null)
            {
                return NotFound();
            }
            var shoppinglist = await _context.ShoppingList.FindAsync(id);

            if (shoppinglist != null)
            {
                ShoppingList = shoppinglist;
                _context.ShoppingList.Remove(ShoppingList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
