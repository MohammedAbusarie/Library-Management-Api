using System;

namespace LibraryManagementApi.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }  //use enum for validation
        public Boolean IsSpecial { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
}
