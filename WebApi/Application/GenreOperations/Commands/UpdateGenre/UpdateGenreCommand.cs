using WebApi.DBOperations;
using System;
using System.Linq;



namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Güncellenecek kitap türü bulunamadı.");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut.");
            genre.Name = string.IsNullOrEmpty(Model.Name.Trim())? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
                


   

        }

        public class UpdateGenreViewModel
        {
            public string Name { get; set; }

            public bool IsActive { get; set; } = true;
        }
    }
}
