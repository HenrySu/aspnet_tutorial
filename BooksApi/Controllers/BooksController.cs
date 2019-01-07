using System.Collections.Generic;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController:ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService){
            this._bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks() => _bookService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Book> GetBook(string id) {
            var book = _bookService.Get(id);
            if(book == null){
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book book){
            _bookService.Create(book);
            return CreatedAtAction("GetBook", new {Id = book.Id.ToString()}, book);
        }

        [HttpPut]
        public IActionResult UpdateBook(string id, Book bookIn){
            var book = _bookService.Get(id);
            if(book == null){
                return NotFound();
            }

            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteBook(string id){
            var book = _bookService.Get(id);
            if(book == null){
                return NotFound();
            }

            _bookService.Remove(book);
            return NoContent();
        }
    }
}