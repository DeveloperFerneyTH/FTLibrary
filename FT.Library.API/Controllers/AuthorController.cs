using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FT.Library.API.Models;
using FT.Library.Core;
using FT.Library.Core.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace FT.Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // Globals
        private RepositoryAccess repository;
        private RegisterLog log;

        public AuthorController(LibraryContext libraryContext, IConfiguration configuration)
        {
            string path = configuration.GetValue<string>("PathRegisterLog");

            // Dependency Injection
            repository = new RepositoryAccess(libraryContext);
            log = new RegisterLog(path);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Authors>> GetAuthors()
        {
            try
            {
                log.WriteLog("Author", MethodBase.GetCurrentMethod().Name, new { });
                var authors = repository.GetAuthors();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Authors> GetAuthorByID(int id)
        {
            try
            {
                log.WriteLog("Author", MethodBase.GetCurrentMethod().Name, new { ID = id });
                var authors = repository.GetAuthorByID(id);
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> CreateAuthor(Authors authors)
        {
            try
            {
                log.WriteLog("Author", MethodBase.GetCurrentMethod().Name, authors);

                if (string.IsNullOrEmpty(authors.FirstName) || string.IsNullOrEmpty(authors.LastName))
                {
                    return BadRequest("El nombre y apellidos son obligatorios");
                }
                
                var result = repository.CreateAuthor(authors);
                ResponseApiGeneric response = new ResponseApiGeneric()
                {
                    ExecuteSuccess = result,
                    Message = result ? "Autor creado correctamente." : "No se logro crear el autor"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> UpdateAuthor(Authors authors)
        {
            try
            {
                log.WriteLog("Author", MethodBase.GetCurrentMethod().Name, authors);

                if (authors.ID == 0)
                {
                    return BadRequest("El id es obligatorio");
                }

                if (string.IsNullOrEmpty(authors.FirstName) || string.IsNullOrEmpty(authors.LastName))
                {
                    return BadRequest("El nombre y apellidos son obligatorios");
                }
                
                var result = repository.UpdateAuthor(authors);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Autor actualizado correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro actualizar el autor";

                    return StatusCode((int)HttpStatusCode.InternalServerError, response);
                }                
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> DeleteAuthor(int id)
        {
            try
            {
                log.WriteLog("Author", MethodBase.GetCurrentMethod().Name, new { ID = id });

                if (id == 0)
                {
                    return BadRequest("El id es obligatorio");
                }
                
                var result = repository.DeleteAuthor(id);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Autor eliminado correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro eliminar el autor";

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
