using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Pages.ShoppingLists
{
    public class EditModel : PageModel
    {
        private readonly ShoppingListApp.Data.ShoppingListAppContext _context;

        public EditModel(ShoppingListApp.Data.ShoppingListAppContext context)
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

            var shoppinglist =  await _context.ShoppingList.FirstOrDefaultAsync(m => m.Id == id);
            if (shoppinglist == null)
            {
                return NotFound();
            }
            ShoppingList = shoppinglist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(ShoppingList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShoppingListExists(int id)
        {
          return (_context.ShoppingList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
