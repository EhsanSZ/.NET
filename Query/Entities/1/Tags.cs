namespace Entities1
{
    public class Tags
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public virtual Post Post { get; set; }
        public long PostId { get; set; }
    }
}
