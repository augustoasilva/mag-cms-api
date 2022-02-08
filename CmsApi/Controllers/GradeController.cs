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
    public class GradeController : Controller
    {
        private readonly IGradeRepository _repo;

        public GradeController(IGradeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _repo.GetAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

        [HttpGet("{gradeId}")]
        public async Task<IActionResult> GetById(int gradeId)
        {
            try
            {
                var result = await _repo.GetByIdAsync(gradeId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostGrade(Grade grade)
        {
            try
            {
                var result = await _repo.AddAsync(grade);
                if (!result)
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

        [HttpPut("{gradeId}")]
        public async Task<IActionResult> PutGrade(Grade grade, int gradeId)
        {
            try
            {
                if (grade.Id != gradeId)
                {
                    throw new Exception("Invalid grade to update!");
                }

                var result = await _repo.UpdateAsync(grade);
                if (!result)
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

        [HttpDelete("{gradeId}")]
        public async Task<IActionResult> DeleteGrade(int gradeId)
        {
            try
            {
                var resultGet = await _repo.GetByIdAsync(gradeId);
                if (resultGet.Id != gradeId)
                {
                    throw new Exception("Invalid grade to update!");
                }

                var result = await _repo.DeleteAsync(resultGet);
                if (!result)
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