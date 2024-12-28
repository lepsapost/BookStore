   using System;

   namespace BookStore.Entities
   {
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; // Varsayılan değer
    public int GenreId { get; set; } // Eksik olan özellik
    public Genre? Genre { get; set; } // İlişkilendirme
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}

   }
