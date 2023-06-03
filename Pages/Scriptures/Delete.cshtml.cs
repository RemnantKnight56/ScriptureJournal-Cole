using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal_Cole.Data;
using ScriptureJournal_Cole.Models;

namespace ScriptureJournal_Cole.Pages.Scriptures
{
    public class DeleteModel : PageModel
    {
        private readonly ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext _context;

        public DeleteModel(ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Scripture Scriptures { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var movie = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);

            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Scriptures = movie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }
            var movie = await _context.Scripture.FindAsync(id);

            if (movie != null)
            {
                Scriptures = movie;
                _context.Scripture.Remove(Scriptures);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
