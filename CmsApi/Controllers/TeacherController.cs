using System;
using System.Threading.Tasks;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repo;

        public TeacherController(ITeacherRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = _repo.GetAsync();
                return Ok(result.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }

        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetById(int teacherId)
        {
            try
            {
                var result = _repo.GetByIdAsync(teacherId);
                return Ok(result.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostTeacher(Teacher teacher)
        {
            try
            {
                var result = _repo.AddAsync(teacher);
                if (!result.Result)
                {
                    throw new Exception("Something went wrong!");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }

        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> PutTeacher(Teacher teacher, int teacherId)
        {
            try
            {
                if (teacher.Id != teacherId)
                {
                    throw new Exception("Invalid teacher to update!");
                }

                var result = _repo.UpdateAsync(teacher);
                if (!result.Result)
                {
                    throw new Exception("Something went wrong!");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }

        }
    }
}