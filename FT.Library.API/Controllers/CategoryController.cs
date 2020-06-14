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
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FT.Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Globals
        private RepositoryAccess repository;
        private RegisterLog log;

        public CategoryController(LibraryContext libraryContext, IConfiguration configuration)
        {
            string path = configuration.GetValue<string>("PathRegisterLog");

            // Dependency Injection
            repository = new RepositoryAccess(libraryContext);
            log = new RegisterLog(path);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Categories>> GetCategories()
        {
            try
            {
                log.WriteLog("Category", MethodBase.GetCurrentMethod().Name, new { });
                var Categorys = repository.GetCategories();
                return Ok(Categorys);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Categories> GetCategoryByID(int id)
        {
            try
            {
                log.WriteLog("Category", MethodBase.GetCurrentMethod().Name, new { ID = id });
                var Categorys = repository.GetCategoryByID(id);
                return Ok(Categorys);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> CreateCategory(Categories category)
        {
            try
            {
                log.WriteLog("Category", MethodBase.GetCurrentMethod().Name, category);

                if (string.IsNullOrEmpty(category.Name))
                {
                    return BadRequest("El nombre de la categoria es obligatorio");
                }

                var result = repository.CreateCategory(category);
                ResponseApiGeneric response = new ResponseApiGeneric()
                {
                    ExecuteSuccess = result,
                    Message = result ? "Categoria creada correctamente." : "No se logro crear la categoria"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> UpdateCategory(Categories category)
        {
            try
            {
                log.WriteLog("Category", MethodBase.GetCurrentMethod().Name, category);

                if (category.ID == 0)
                {
                    return BadRequest("El id es obligatorio");
                }

                if (string.IsNullOrEmpty(category.Name))
                {
                    return BadRequest("El nombre de la categoria es obligatorio");
                }

                var result = repository.UpdateCategory(category);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Categoria actualizada correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro actualizar la categoria";

                    return StatusCode((int)HttpStatusCode.InternalServerError, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ResponseApiGeneric> DeleteCategory(int id)
        {
            try
            {
                log.WriteLog("Category", MethodBase.GetCurrentMethod().Name, new { ID = id });

                if (id == 0)
                {
                    return BadRequest("El id es obligatorio");
                }

                var result = repository.DeleteCategory(id);
                ResponseApiGeneric response = new ResponseApiGeneric();
                if (result)
                {
                    response.ExecuteSuccess = result;
                    response.Message = "Categoria eliminada correctamente.";

                    return Ok(response);
                }
                else
                {
                    response.ExecuteSuccess = result;
                    response.Message = "No se logro eliminar la categoria";

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
