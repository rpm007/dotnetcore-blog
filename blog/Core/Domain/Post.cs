using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; }       

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaAuthor { get; set; }

        public string MetaKeywords { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
