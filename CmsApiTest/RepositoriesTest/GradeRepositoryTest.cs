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

public class GradeRepositoryTest
{
    private readonly DataContext _context;

    public GradeRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );

        _context = new DataContext(dbOptions.Options);
    }

    [Fact]
    public async Task ShouldAddGrade()
    {
        // Arrange
        var repo = new Repository<Grade>(_context);
        var sut = new GradeRepository(repo);
        var item = new Grade() {Id = 1, StudentId = 1, SubjectId = 1, Value = 9.5};

        // Act
        var result = await sut.AddAsync(item);

        // Assert
        var items = _context.Grades.ToList();
        Assert.True(result);
        Assert.Single(items);
    }

    [Fact]
    public async Task ShouldGetGrade()
    {
        // Arrange
        const int itemId = 2;
        _context.Grades.Add(new Grade() {Id = 2, StudentId = 1, SubjectId = 1, Value = 7.25});
        await _context.SaveChangesAsync();

        var repo = new Repository<Grade>(_context);
        var sut = new GradeRepository(repo);

        // Act
        var result = await sut.GetByIdAsync(itemId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldGetAllGrades()
    {
        // Arrange
        var Grades = new List<Grade>()
        {
            new Grade() {Id = 3, StudentId = 1, SubjectId = 1, Value = 8.0},
            new Grade() {Id = 4, StudentId = 1, SubjectId = 2, Value = 8.5}
        };

        _context.Grades.AddRange(Grades);
        await _context.SaveChangesAsync();

        var repo = new Repository<Grade>(_context);
        var sut = new GradeRepository(repo);

        // Act
        var result = await sut.GetAsync();

        // Assert
        Assert.Equal(Grades.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateGrade()
    {
        // Arrange
        _context.Grades.Add(new Grade() {Id = 5, StudentId = 1, SubjectId = 2, Value = 8.7});
        await _context.SaveChangesAsync();

        var toUpdateGrade = new Grade() {Id = 5, StudentId = 1, SubjectId = 2, Value = 7.7};

        var repo = new Repository<Grade>(_context);
        var sut = new GradeRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateGrade);

        // Assert
        Assert.True(result);
    }
}