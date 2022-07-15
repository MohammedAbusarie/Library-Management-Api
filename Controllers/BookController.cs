using LibraryManagementApi.Data.DTOs;
using LibraryManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementApi.Controllers
{
    //[controller]
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _service.GetBooks());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBooks(int id)
        {
            return Ok(await _service.GetBooks(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO bookDTO)
        {
            return Ok(await _service.AddBook(bookDTO));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _service.DeleteBook(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id,[FromBody] BookDTO bookDTO)
        {
            return Ok(await _service.UpdateBook(id, bookDTO));
        }

    }
}
