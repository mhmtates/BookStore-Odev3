using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System;
using System.Linq;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author != null)
                throw new InvalidOperationException("Böyle bir yazar mevcut.");
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();

        }

        public class CreateAuthorViewModel
        {

           

            public string Name { get; set; }


            public string Surname { get; set; }


            public DateTime BirthDate { get; set; }


        }



    }
}
