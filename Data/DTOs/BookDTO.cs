using System;

namespace LibraryManagementApi.Data.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }  //use enum for validation
        public Boolean IsSpecial { get; set; }
    }
}
