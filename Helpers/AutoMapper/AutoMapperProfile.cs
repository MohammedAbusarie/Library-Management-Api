using AutoMapper;
using LibraryManagementApi.Data.DTOs;
using LibraryManagementApi.Data.Models;
using System;

namespace LibraryManagementApi.Helpers.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //source, destination
            CreateMap<BookDTO, Book>()
                .ForMember(b => b.CreatedAt, o => o.MapFrom(s => DateTimeOffset.Now )); ;
        }
    }
}
