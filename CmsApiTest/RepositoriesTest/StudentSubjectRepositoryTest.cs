using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsApi.Data;
using CmsApi.Models;
using CmsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CmsApiTest.RepositoriesTest;

public class StudentSubjectRepositoryTest
{
    private readonly DataContext _context;

    public StudentSubjectRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );

        _context = new DataContext(dbOptions.Options);
    }

    [Fact]
    public async Task ShouldAddStudentSubject()
    {
        // Arrange
        var repo = new Repository<StudentSubject>(_context);
        var sut = new StudentSubjectRepository(repo);
        var item =  new StudentSubject(){ StudentId = 1, SubjectId = 1};

        // Act
        var result = await sut.AddAsync(item);

        // Assert
        var items = _context.StudentSubjects.ToList();
        Assert.True(result);
        Assert.Single(items);
    }

    [Fact]
    public async Task ShouldGetStudentSubject()
    {
        // Arrange
        const int id1 = 1;
        const int id2 = 2;
        _context.StudentSubjects.Add( new StudentSubject(){ StudentId = 1, SubjectId = 2});
        await _context.SaveChangesAsync();

        var repo = new Repository<StudentSubject>(_context);
        var sut = new StudentSubjectRepository(repo);

        // Act
        var result = await sut.GetByIdAsync(id1, id2);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldGetAllStudentSubjects()
    {
        // Arrange
        var StudentSubjects = new List<StudentSubject>()
        {
            new StudentSubject(){ StudentId = 1, SubjectId = 5},
            new StudentSubject(){ StudentId = 2, SubjectId = 1}
        };

        _context.StudentSubjects.AddRange(StudentSubjects);
        await _context.SaveChangesAsync();

        var repo = new Repository<StudentSubject>(_context);
        var sut = new StudentSubjectRepository(repo);

        // Act
        var result = await sut.GetAsync();

        // Assert
        Assert.Equal(StudentSubjects.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateStudentSubject()
    {
        // Arrange
        _context.StudentSubjects.Add(new StudentSubject(){ StudentId = 2, SubjectId = 2});
        await _context.SaveChangesAsync();

        var toUpdateStudentSubject = new StudentSubject(){ StudentId = 3, SubjectId = 2};

        var repo = new Repository<StudentSubject>(_context);
        var sut = new StudentSubjectRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateStudentSubject);

        // Assert
        Assert.True(result);
    }
}