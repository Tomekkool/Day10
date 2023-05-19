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
    public class IndexModel : PageModel
    {
        private readonly VolleyballDbContext _context;

        public IndexModel(VolleyballDbContext context)
        {
            _context = context;
        }

        public IList<VolleyballPlayer> VolleyballPlayer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.VolleyballPlayer != null)
            {
                VolleyballPlayer = await _context.VolleyballPlayer.ToListAsync();
            }
        }
    }
}
