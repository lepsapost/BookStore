   namespace BookStore.Models
   {
      public class BookDetailViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int PageCount { get; set; }
    public string PublishDate { get; set; } = string.Empty;
}
   }
