using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerkwazView.Models
{
    public class Blog
    {
        private int key;
        private string author;
        private string title;
        private string subtTitle;
        private string imageUrl;
        private string body;
        private DateTime creationDate;

        public Blog(string author, string title, string subtTitle, string imageUrl, string body, DateTime creationDate)
        {
            this.Author = author;
            this.Title = title;
            this.SubtTitle = subtTitle;
            this.ImageUrl = imageUrl;
            this.Body = body;
            this.CreationDate = creationDate;
        }

        public Blog()
        {
        }

        public string Author { get => author; set => author = value; }
        public string Title { get => title; set => title = value; }
        public string SubtTitle { get => subtTitle; set => subtTitle = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string Body { get => body; set => body = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public int Key { get => key; set => key = value; }
    }
}
