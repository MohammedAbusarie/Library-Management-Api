using LibraryManagementApi.Data;
using LibraryManagementApi.Data.DTOs;
using LibraryManagementApi.Data.Models;
using LibraryManagementApi.Helpers.ErrorHandling;
using System;

namespace LibraryManagementApi.Services
{
    public class SeedingDbService
    {
        private readonly ApplicationDbContext _context;
        enum BookType {
            Science,
            Politics,
            Arts}
        public SeedingDbService(ApplicationDbContext context)
        {
            _context = context;
        }
        public GlobalResponseDTO PopulateBooks(int NumOfEntries)
        {
            if (NumOfEntries <= 0) throw new AppException("Can't enter a negative number");

            Random random = new Random();
            Array values = Enum.GetValues(typeof(BookType));

            for(int i = 0; i < NumOfEntries; i++)
            {
                Book book = new Book();

                book.Name = Faker.Name.First();
                book.CreatedAt = System.DateTimeOffset.UtcNow;
                book.IsSpecial = Faker.Boolean.Random(); //random.Next(100) < 40;
                book.Description = Faker.Lorem.Sentence(5);
                book.Type = ((BookType)values.GetValue(random.Next(values.Length))).ToString();

                _context.Books.Add(book);
            }

            _context.SaveChanges();

            return new GlobalResponseDTO(
                "Populated Book Table Successfully",
                String.Format("{0} records added to database successfully",  NumOfEntries) 
                );
        }
    }
}
