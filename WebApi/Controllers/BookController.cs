using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using WebApi.Application.BookOperations.Commands.CreateBook;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Commands.DeleteBookCommand;
using WebApi.BookOperations.Queries.GetBooks;
using static WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery bookquery = new GetBooksQuery(_context,_mapper);
            var result = bookquery.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

                BookDetailViewModel result;
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{

        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //} 

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookViewModel newBook)
        {

                CreateBookCommand command = new CreateBookCommand(_context,_mapper);
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            //  if (!result.IsValid)
            //     foreach (var item in result.Errors)
             //      Console.WriteLine("Özellik: " + item.PropertyName + "- Error Message: " + item.ErrorMessage);
            //  else
            //  command.Handle();
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}

            return Ok();

        }
        //Put
        [HttpPut("id")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updatedBook)
        {
          
                UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
                command.BookId = id;
                command.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();

        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

    }

}