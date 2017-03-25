using System;
using System.Collections.Generic;
using System.Text;

namespace ITStore.Domain.Entities
{
    public class Post
    {
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public int Points { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Text { get; set; }
        public string Topic { get; set; }
        public bool HelpfulAnswer { get; set; }
    }
}
