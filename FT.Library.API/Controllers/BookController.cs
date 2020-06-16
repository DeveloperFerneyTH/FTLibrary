using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FT.Library.API.Models;
using FT.Library.Core;
using FT.Library.Core.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FT.Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        // Globals
        private RepositoryAccess repository;
        private RegisterLog log;

        public BookController(LibraryContext libraryContext, IConfiguration configuration)
        {
            string path = configuration.GetValue<string>("PathRegisterLog");

            // Dependency Injection
            repository = new RepositoryAccess(libraryContext);
            log = new RegisterLog(path);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<BookModel>> GetBooks()
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { });
                List<BookModel> books = (from book in repository.GetBooks()
                                         join author in repository.GetAuthors()
                                         on book.Author_ID equals author.ID
                                         join category in repository.GetCategories()
                                         on book.Category_ID equals category.ID
                                         orderby book.Name
                                         select new BookModel()
                                         {
                                             Author_ID = book.Author_ID,
                                             Author_Name = $"{author.FirstName} {author.LastName}",
                                             Category_ID = book.Category_ID,
                                             Category_Name = category.Name,
                                             ID = book.ID,
                                             ISBN = book.ISBN,
                                             Name = book.Name
                                         }).ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<BookModel> GetBookByID(int id)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { ID = id });
                var bookModel = from book in repository.GetBooks()
                                   join author in repository.GetAuthors()
                                   on book.Author_ID equals author.ID
                                   join category in repository.GetCategories()
                                   on book.Category_ID equals category.ID
                                   where book.ID == id
                                   select new BookModel()
                                   {
                                       Author_ID = book.Author_ID,
                                       Author_Name = $"{author.FirstName} {author.LastName}",
                                       Category_ID = book.Category_ID,
                                       Category_Name = category.Name,
                                       ID = book.ID,
                                       ISBN = book.ISBN,
                                       Name = book.Name
                                   };

                return Ok(bookModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<BookModel> GetBookByName(string name)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { Name = name });
                var bookModel = from book in repository.GetBooks()
                                join author in repository.GetAuthors()
                                on book.Author_ID equals author.ID
                                join category in repository.GetCategories()
                                on book.Category_ID equals category.ID
                                where book.Name.Contains(name)
                                select new BookModel()
                                {
                                    Author_ID = book.Author_ID,
                                    Author_Name = $"{author.FirstName} {author.LastName}",
                                    Category_ID = book.Category_ID,
                                    Category_Name = category.Name,
                                    ID = book.ID,
                                    ISBN = book.ISBN,
                                    Name = book.Name
                                };

                return Ok(bookModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{authorID}")]
        public ActionResult<Books> GetBookByAuthor(int authorID)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { AuthorID = authorID });
                var bookModel = from book in repository.GetBooks()
                                join author in repository.GetAuthors()
                                on book.Author_ID equals author.ID
                                join category in repository.GetCategories()
                                on book.Category_ID equals category.ID
                                where book.Author_ID == authorID
                                select new BookModel()
                                {
                                    Author_ID = book.Author_ID,
                                    Author_Name = $"{author.FirstName} {author.LastName}",
                                    Category_ID = book.Category_ID,
                                    Category_Name = category.Name,
                                    ID = book.ID,
                                    ISBN = book.ISBN,
                                    Name = book.Name
                                };

                return Ok(bookModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{categoryID}")]
        public ActionResult<Books> GetBookByCategory(int categoryID)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { CategoryID = categoryID });
                var bookModel = from book in repository.GetBooks()
                                join author in repository.GetAuthors()
                                on book.Author_ID equals author.ID
                                join category in repository.GetCategories()
                                on book.Category_ID equals category.ID
                                where book.Category_ID == categoryID
                                select new BookModel()
                                {
                                    Author_ID = book.Author_ID,
                                    Author_Name = $"{author.FirstName} {author.LastName}",
                                    Category_ID = book.Category_ID,
                                    Category_Name = category.Name,
                                    ID = book.ID,
                                    ISBN = book.ISBN,
                                    Name = book.Name
                                };

                return Ok(bookModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> CreateBook(Books books)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, books);

                if (string.IsNullOrEmpty(books.Name))
                {
                    return BadRequest("El nombre del libro es obligatorio");
                }

                if (string.IsNullOrEmpty(books.ISBN))
                {
                    return BadRequest("El ISBN del libro es obligatorio");
                }

                var result = repository.CreateBook(books);
                ResponseApiGeneric response = new ResponseApiGeneric()
                {
                    ExecuteSuccess = result,
                    Message = result ? "Libro creado correctamente." : "No se logro crear el libro"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> UpdateBook(Books books)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, books);

                if (books.ID == 0)
                {
                    return BadRequest("El id es obligatorio");
                }

                if (string.IsNullOrEmpty(books.Name))
                {
                    return BadRequest("El nombre del libro es obligatorio");
                }

                if (string.IsNullOrEmpty(books.ISBN))
                {
                    return BadRequest("El ISBN del libro es obligatorio");
                }

                var result = repository.UpdateBook(books);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Libro actualizado correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro actualizar el libro";

                    return StatusCode((int)HttpStatusCode.InternalServerError, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> DeleteBook(int id)
        {
            try
            {
                log.WriteLog("Book", MethodBase.GetCurrentMethod().Name, new { ID = id});

                if (id == 0)
                {
                    return BadRequest("El id es obligatorio");
                }

                var result = repository.DeleteBook(id);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Libro eliminado correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro eliminar el libro";

                    return StatusCode((int)HttpStatusCode.InternalServerError, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
