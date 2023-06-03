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
    public class DetailsModel : PageModel
    {
        private readonly ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext _context;

        public DetailsModel(ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext context)
        {
            _context = context;
        }

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
    }
}
