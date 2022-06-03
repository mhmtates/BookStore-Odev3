using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public UpdateAuthorViewModel Model { get; set; }
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı.");
            if (_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Aynı isimli bir yazar zaten mevcut.");
            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            author.BirthDate = Model.BirthDate;
            author.IsActive = Model.IsActive;
            _context.SaveChanges();


        }

        public class UpdateAuthorViewModel
        {
            public string Name { get; set; }


            public string Surname { get; set; }


            public DateTime BirthDate { get; set; }


            public bool IsActive { get; set; }


        }

    }

}
