using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null) return NotFound();

            return book;
        }
    }
}
