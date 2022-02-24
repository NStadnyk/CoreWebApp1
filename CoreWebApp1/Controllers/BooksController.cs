using CoreWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static List<Book> _books;
        private readonly ILogger<BooksController> _logger;

        static BooksController()
        {
            _books = new List<Book>();
        }

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Id = Guid.NewGuid();
            _books.Add(book);
            return Ok(book);
        }
        [HttpGet]
        public IActionResult GetAllBook()
        {
            return Ok(_books);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdBook(Guid id)
        {
            Book book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult UpdateIdBook(Book book)
        {
            Book dbBook = _books.FirstOrDefault(x => x.Id == book.Id);
            if(dbBook!=null)
            {
                var index = _books.IndexOf(dbBook);
                _books[index] = book;

                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooks(Guid id)
        {
            Book dbBook = _books.FirstOrDefault(x => x.Id == id);
            if (dbBook != null)
            {
                _books.Remove(dbBook);

                return Ok(dbBook);
            }
            return NotFound();
        }
    }
}