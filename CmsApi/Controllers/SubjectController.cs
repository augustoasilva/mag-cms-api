using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : Controller
{
private readonly ISubjectRepository _repo;

    public SubjectController(ISubjectRepository repo)
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

    [HttpGet("{subjectId}")]
    public async Task<IActionResult> GetById(int subjectId)
    {
        try
        {
            var result = await _repo.GetByIdAsync(subjectId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostSubject(Subject subject)
    {
        try
        {
            var result = await _repo.AddAsync(subject);
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

    [HttpPut("{subjectId}")]
    public async Task<IActionResult> PutSubject(Subject subject, int subjectId)
    {
        try
        {
            if (subject.Id != subjectId)
            {
                throw new Exception("Invalid subject to update!");
            }

            var result = await _repo.UpdateAsync(subject);
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

    [HttpDelete("{subjectId}")]
    public async Task<IActionResult> DeleteSubject(int subjectId)
    {
        try
        {
            var resultGet = await _repo.GetByIdAsync(subjectId);
            if (resultGet.Id != subjectId)
            {
                throw new Exception("Invalid subject to update!");
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