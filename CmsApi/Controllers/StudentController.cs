using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _repo;
    private readonly IGradeRepository _gradeRepo;

    public StudentController(IStudentRepository repo, IGradeRepository gradeRepo)
    {
        _repo = repo;
        _gradeRepo = gradeRepo;
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
    
    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetById(int studentId)
    {
        try
        {
            var result = _repo.GetByIdAsync(studentId);
            return Ok(result.Result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
        }
        
    }
    
    [HttpGet("{studentId}/grades/{subjectId}")]
    public async Task<IActionResult> GetStudentGradesById(int studentId, int subjectId)
    {
        try
        {
            var result = _gradeRepo.GetGradeByStudentIdAndSubjectIdAsync(studentId, subjectId);
            return Ok(result.Result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> PostStudent(Student student)
    {
        try
        {
            var result = _repo.AddAsync(student);
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
    
    [HttpPut("{studentId}")]
    public async Task<IActionResult> PutStudent(Student student, int studentId)
    {
        try
        {
            if (student.Id != studentId)
            {
                throw new Exception("Invalid student to update!");
            }
                
            var result = _repo.UpdateAsync(student);
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