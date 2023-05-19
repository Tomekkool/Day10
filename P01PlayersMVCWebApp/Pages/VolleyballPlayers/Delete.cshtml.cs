using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P01PlayersMVCWebApp.Models;

namespace P01PlayersMVCWebApp.Pages.VolleyballPlayers
{
    public class DeleteModel : PageModel
    {
        private readonly VolleyballDbContext _context;

        public DeleteModel(VolleyballDbContext context)
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

            var volleyballplayer = await _context.VolleyballPlayer.FirstOrDefaultAsync(m => m.Id == id);

            if (volleyballplayer == null)
            {
                return NotFound();
            }
            else 
            {
                VolleyballPlayer = volleyballplayer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.VolleyballPlayer == null)
            {
                return NotFound();
            }
            var volleyballplayer = await _context.VolleyballPlayer.FindAsync(id);

            if (volleyballplayer != null)
            {
                VolleyballPlayer = volleyballplayer;
                _context.VolleyballPlayer.Remove(VolleyballPlayer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
