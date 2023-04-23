namespace Infrastructure.Models
{
    public class ShopActionResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int Total { get; set; } //=> 1469
        public int Page { get; set; } //=> 3
        public int PageCount { 
            get{
                if(Total == 0) return 0;
                return Convert.ToInt32(Math.Ceiling(Total/(double)Size));
            }
         } //=> (Total/Size) => 73.45 ? => Math.Ceiling(74)
        public int Size { get; set; } //=> 20
    }
}

//Generic
//الگوریتم یکسان با نوع داده های متفاوت