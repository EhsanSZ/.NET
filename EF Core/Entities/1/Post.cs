using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Post
    {
        private ICollection<Comment> _Comments;
        private ILazyLoader _lazyLoader;
        public Post()
        {

        }

        public Post(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime InsertDate { get; set; }
        public  virtual ICollection<Comment> Comments
        {
            get => _lazyLoader.Load(this, ref _Comments);
            set => _Comments = value;
        }
        public  virtual ICollection<Tags> Tags { get; set; }
        public  virtual Category Category { get; set; }
    }
}
