using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Pages.ShoppingLists
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingListApp.Data.ShoppingListAppContext _context;

        public CreateModel(ShoppingListApp.Data.ShoppingListAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShoppingList ShoppingList { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ShoppingList == null || ShoppingList == null)
            {
                return Page();
            }

            _context.ShoppingList.Add(ShoppingList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
