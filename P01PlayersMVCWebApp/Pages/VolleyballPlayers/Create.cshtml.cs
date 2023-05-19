using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P01PlayersMVCWebApp.Models;

namespace P01PlayersMVCWebApp.Pages.VolleyballPlayers
{
    public class CreateModel : PageModel
    {
        private readonly VolleyballDbContext _context;

        public CreateModel(VolleyballDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VolleyballPlayer VolleyballPlayer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.VolleyballPlayer == null || VolleyballPlayer == null)
            {
                return Page();
            }

            _context.VolleyballPlayer.Add(VolleyballPlayer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
