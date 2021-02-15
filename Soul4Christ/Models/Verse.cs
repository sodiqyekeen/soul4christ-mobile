using System;

namespace Soul4Christ.Models
{
    public class Verse
    {
        public string VerseId { get; set; }
        public string Book { get; set; }
        public string Content { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
