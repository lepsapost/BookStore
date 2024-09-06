   using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using BookStore.Models;
   using BookStore.DBOperations;
   using System;
   using System.Linq;
   using BookStore.Entities;

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
    if (book == null)
        return NotFound();

    BookDetailViewModel vm = new BookDetailViewModel()
    {
        Id = book.Id,
        Title = book.Title,
        Genre = book.Genre?.Name,
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
