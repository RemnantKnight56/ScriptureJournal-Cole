using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal_Cole.Models
{

    public class Scripture
    {
        public int ID { get; set; }

        //[RegularExpression(@"[0-9A-Za-z&]")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Display(Name = "Chapter & Verse")]
        //[RegularExpression(@"[0-9:,]")]
        [Required]
        public string ChapterVerse { get; set; }

        [StringLength(60)]
        public string Note { get; set; } = string.Empty;

        [Display(Name = "Date Added")]
        // [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
