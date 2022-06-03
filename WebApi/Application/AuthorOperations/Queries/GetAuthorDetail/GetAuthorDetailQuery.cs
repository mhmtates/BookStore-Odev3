using AutoMapper;
using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public int AuthorId { get; set; }


        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı!");
            AuthorDetailViewModel avm = _mapper.Map<AuthorDetailViewModel>(author);
            return avm;

       }

        public class AuthorDetailViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }


            public string Surname { get; set; }


            public string BirthDate { get; set; }


        } 
            

    }
}
