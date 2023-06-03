using Microsoft.EntityFrameworkCore;
using ScriptureJournal_Cole.Data;

namespace ScriptureJournal_Cole.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournal_ColeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournal_ColeContext>>()))
            {
                if (context == null || context.Scripture == null)
                {
                    throw new ArgumentNullException("Null ScriptureJournalContext");
                }

                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Genesis",
                        ChapterVerse = "5:11",
                        DateAdded = DateTime.Parse("2021-2-12"),
                        Note = "N/A"
                    },

                    new Scripture
                    {
                        Book = "1 Nephi",
                        ChapterVerse = "3:18",
                        DateAdded = DateTime.Parse("2022-5-30"),
                        Note = "This is a test"
                    },

                    new Scripture
                    {
                        Book = "Matthew",
                        ChapterVerse = "12:24",
                        DateAdded = DateTime.Parse("2020-11-26"),
                        Note = "Hello, test!"
                    },

                    new Scripture
                    {
                        Book = "D&C",
                        ChapterVerse = "75:5",
                        DateAdded = DateTime.Parse("2022-12-4"),
                        Note = "No more tests!"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
