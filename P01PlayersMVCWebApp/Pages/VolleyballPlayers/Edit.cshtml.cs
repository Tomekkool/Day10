using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P01PlayersMVCWebApp.Models;

namespace P01PlayersMVCWebApp.Pages.VolleyballPlayers
{
    public class EditModel : PageModel
    {
        private readonly VolleyballDbContext _context;

        public EditModel(VolleyballDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VolleyballPlayer VolleyballPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VolleyballPlayer == null)
            {
                return NotFound();
            }

            var volleyballplayer =  await _context.VolleyballPlayer.FirstOrDefaultAsync(m => m.Id == id);
            if (volleyballplayer == null)
            {
                return NotFound();
            }
            VolleyballPlayer = volleyballplayer;
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

            _context.Attach(VolleyballPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolleyballPlayerExists(VolleyballPlayer.Id))
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

        private bool VolleyballPlayerExists(int id)
        {
          return (_context.VolleyballPlayer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
