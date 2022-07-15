using AutoMapper;
using LibraryManagementApi.Data;
using LibraryManagementApi.Data.DTOs;
using LibraryManagementApi.Data.Models;
using LibraryManagementApi.Helpers.ErrorHandling;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApi.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //post
        public async Task<GlobalResponseDTO> AddBook(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return new GlobalResponseDTO("Added Book Successfully", book);
        }

        //get
        public async Task<GlobalResponseDTO> GetBooks()
        {
            var books = await _context.Books.ToListAsync();

            if (!books.Any())
                throw new AppException("No Records Available");

            return new GlobalResponseDTO("Fetched Books Successfully", books);

        }

        //get id
        public async Task<GlobalResponseDTO> GetBooks(int id)
        {
            Book book = await _findBookById(id);
            return new GlobalResponseDTO( "Fetched Book Successfully",book );   
        }

        //delete
        public async Task<GlobalResponseDTO> DeleteBook(int id)
        {
            Book book = await _findBookById(id);
            _context.Remove(book);
            _context.SaveChanges();
            return new GlobalResponseDTO("Deleted Book Successfully", book);
        }

        //put
        public async Task<GlobalResponseDTO> UpdateBook(int id,BookDTO bookDTO)
        {
            Book book = await _findBookById(id);
            book = _mapper.Map<BookDTO,Book>(bookDTO,book);
            await _context.SaveChangesAsync();
            return new GlobalResponseDTO("Updated Book Successfully", book);
        }

        // <===== private methods =====>
        private async Task<Book> _findBookById(int id)
        {
            Book book = await _context.Books.Where(book => book.Id == id).FirstOrDefaultAsync();

            if (book == null)
                throw new AppException("Invalid ID");

            return book;
        }

    }
}
