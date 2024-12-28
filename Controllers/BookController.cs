   using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using BookStore.Models;
   using BookStore.DBOperations;
   using System;
   using System.Linq;
   using BookStore.Entities;
   using System.Diagnostics;


   namespace BookStore.Controllers
   {
       [ApiController]
       [Route("api/[controller]")]
       public class BookController : ControllerBase
       {
           private readonly BookStoreDbContext _context;

           public BookController(BookStoreDbContext context)
           {
               _context = context;
           }

          [HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var book = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
   if (book == null || book.Genre == null)
    return NotFound();

    BookDetailViewModel vm = new BookDetailViewModel()
    {
        Id = book.Id,
        Title = book.Title,
        Genre = book.Genre?.Name ?? "Unknown", // Null kontrolü yapıldı
        PageCount = book.PageCount,
        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
    };

    return Ok(vm);
}
        [HttpGet]
public IActionResult GetBooks()
{
    var bookList = _context.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList();
    var vm = bookList.Select(book => new BookDetailViewModel()
    {
        Id = book.Id,
        Title = book.Title,
        Genre = book.Genre?.Name,
        PageCount = book.PageCount,
        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
    });
    return Ok(vm);
}
[HttpGet("recommend")]
public IActionResult GetRecommendations(int userId)
{
    var start = new ProcessStartInfo
    {
        FileName = "C:\\Windows\\py.exe", // Python yorumlayıcıyı çağır
        Arguments = $"Scripts/recommendation.py 1 {userId}", // Python scriptini çağır ve userId'yi parametre olarak gönder
        RedirectStandardOutput = true, // Python çıktısını yakala
        RedirectStandardError = true,  // Hataları yakala
        UseShellExecute = false,       // Komut işlemeyi gösterme
        CreateNoWindow = true,         // Yeni pencere açma
        WorkingDirectory = "C:\\Users\\90537\\Desktop\\cache\\dotnet\\BookStore"
    };

    string result;

    using (var process = Process.Start(start))
    {
        using (var reader = process.StandardOutput)
        {
            result = reader.ReadToEnd(); // Python scriptinin çıktısını oku
        }
    }

    // Eğer çıktı yoksa hata döndür
    if (string.IsNullOrEmpty(result))
    {
        return StatusCode(500, "No recommendations received from Python script.");
    }

    // Çıktıyı başarıyla döndür
    return Ok(result);
}

           [HttpPut("{id}")]
           public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
           {
               var book = _context.Books.SingleOrDefault(x => x.Id == id);
               if (book == null)
                   return NotFound();

               book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
               book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
               book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
               book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;

               _context.SaveChanges();

               return Ok();
           }
           [HttpPost]
    public IActionResult AddBook([FromBody] UpdateBookModel newBook)
    {
        var book = new Book
        {

            Title = newBook.Title,
            GenreId = newBook.GenreId,
            PageCount = newBook.PageCount,
            PublishDate = newBook.PublishDate
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        var addedBookViewModel = new BookDetailViewModel
    {
        Id = book.Id,
        Title = book.Title,
        Genre = _context.Genres.FirstOrDefault(g => g.Id == book.GenreId)?.Name ?? "Unknown",
        PageCount = book.PageCount,
        PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
    };

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

       }
   }
