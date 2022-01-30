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

public class SubjectRepositoryTest
{
    private readonly DataContext _context;

    public SubjectRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );

        _context = new DataContext(dbOptions.Options);
    }

    [Fact]
    public async Task ShouldAddSubject()
    {
        // Arrange
        var repo = new Repository<Subject>(_context);
        var sut = new SubjectRepository(repo);
        var item =  new Subject(1, "Calculus 1", 1, 1);

        // Act
        var result = await sut.AddAsync(item);

        // Assert
        var items = _context.Subjects.ToList();
        Assert.True(result);
        Assert.Single(items);
    }

    [Fact]
    public async Task ShouldGetSubject()
    {
        // Arrange
        const int itemId = 2;
        _context.Subjects.Add( new (2, "Physics 1", 2, 1));
        await _context.SaveChangesAsync();

        var repo = new Repository<Subject>(_context);
        var sut = new SubjectRepository(repo);

        // Act
        var result = await sut.GetByIdAsync(itemId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldGetAllSubjects()
    {
        // Arrange
        var Subjects = new List<Subject>()
        {
            new Subject(3, "Algorithms 1", 3, 2),
            new Subject(4, "Linear Algebra", 4, 2)
        };

        _context.Subjects.AddRange(Subjects);
        await _context.SaveChangesAsync();

        var repo = new Repository<Subject>(_context);
        var sut = new SubjectRepository(repo);

        // Act
        var result = await sut.GetAsync();

        // Assert
        Assert.Equal(Subjects.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateSubject()
    {
        // Arrange
        _context.Subjects.Add(new Subject(5, "2D CAD Design", 5, 1));
        await _context.SaveChangesAsync();

        var toUpdateSubject = new Subject(5, "3D CAD Design", 5, 1);

        var repo = new Repository<Subject>(_context);
        var sut = new SubjectRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateSubject);

        // Assert
        Assert.True(result);
    }
}