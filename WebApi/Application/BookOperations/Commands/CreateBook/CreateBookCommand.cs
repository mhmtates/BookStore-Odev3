﻿using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookViewModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut");
            book = _mapper.Map<Book>(Model);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public class CreateBookViewModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }

            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }
        }
    }
}
