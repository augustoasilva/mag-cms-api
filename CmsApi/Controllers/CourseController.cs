using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : Controller
{
    private readonly ICourseRepository _repo;

    public CourseController(ICourseRepository repo)
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
    
    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetById(int courseId)
    {
        try
        {
            var result = await _repo.GetByIdAsync(courseId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> PostCourse(Course course)
    {
        try
        {
            var result = await  _repo.AddAsync(course);
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
    
    [HttpPut("{courseId}")]
    public async Task<IActionResult> PutCourse(Course course, int courseId)
    {
        try
        {
            if (course.Id != courseId)
            {
                throw new Exception("Invalid course to update!");
            }
                
            var result = await _repo.UpdateAsync(course);
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
    
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourse(int courseId)
    {
        try
        {
            var resultGet = await _repo.GetByIdAsync(courseId);
            if (resultGet.Id != courseId)
            {
                throw new Exception("Invalid course to update!");
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