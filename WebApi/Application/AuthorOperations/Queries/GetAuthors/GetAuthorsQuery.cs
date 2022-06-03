using AutoMapper;
using WebApi.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<AuthorsViewModel> avm = _mapper.Map<List<AuthorsViewModel>>(authors);
            return avm;
        }


        public class AuthorsViewModel
        {
           

            public string Name { get; set; }

            public string Surname { get; set; }


            public string BirthDate { get; set; }


         
        }
    }
}
