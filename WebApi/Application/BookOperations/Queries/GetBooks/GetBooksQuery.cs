using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Genre).Include(y=>y.Author).OrderBy(z => z.Id).ToList<Book>();
            List<BooksViewModel> bvm = _mapper.Map<List<BooksViewModel>>(bookList);
           
            return bvm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }

            public int PageCount { get; set; }

            public string PublishDate{ get; set; }

            public string Genre { get; set; }
        }

    }
}
