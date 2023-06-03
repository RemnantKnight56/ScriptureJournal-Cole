using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal_Cole.Data;
using ScriptureJournal_Cole.Models;

namespace ScriptureJournal_Cole.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext _context;

        public IndexModel(ScriptureJournal_Cole.Data.ScriptureJournal_ColeContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilterType { get; set;}

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            var scriptures = from m in _context.Scripture
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookType))
            {
                scriptures = scriptures.Where(x => x.Book == BookType);
            }
            if (!string.IsNullOrEmpty(FilterType))
            {
                switch (FilterType)
                {
                    case "Book Down":
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;

                    case "Book Up":
                        scriptures = scriptures.OrderByDescending(s => s.Book);
                        break;

                    case "Date Down":
                        scriptures = scriptures.OrderByDescending(s => s.DateAdded);
                        break;

                    case "Date Up":
                        scriptures = scriptures.OrderBy(s => s.DateAdded);
                        break;

                    default:
                        break;
                }

                
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
