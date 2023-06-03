using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureJournal_Cole.Data;
using ScriptureJournal_Cole.Models;

namespace ScriptureJournal_Cole.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext _context;

        public CreateModel(ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Scripture == null || Scripture == null)
            {
                return Page();
            }

            Scripture.DateAdded = DateTime.Now;
            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
