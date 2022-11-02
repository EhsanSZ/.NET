using System;

namespace Entities2
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime SendDate { get; set; }

        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual Post Post { get; set; }
        public long PostId { get; set; }
    }
}
