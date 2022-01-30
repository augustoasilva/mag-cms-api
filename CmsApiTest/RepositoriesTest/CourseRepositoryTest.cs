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

public class CourseRepositoryTest
{
    private readonly DataContext _context;

    public CourseRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );

        _context = new DataContext(dbOptions.Options);
    }

    [Fact]
    public async Task ShouldAddCourse()
    {
        // Arrange
        var repo = new Repository<Course>(_context);
        var sut = new CourseRepository(repo);
        var item =  new Course(1, "Mechanical Engineering");

        // Act
        var result = await sut.AddAsync(item);

        // Assert
        var items = _context.Courses.ToList();
        Assert.True(result);
        Assert.Single(items);
    }

    [Fact]
    public async Task ShouldGetCourse()
    {
        // Arrange
        const int itemId = 2;
        _context.Courses.Add( new Course(2, "Software Engineering"));
        await _context.SaveChangesAsync();

        var repo = new Repository<Course>(_context);
        var sut = new CourseRepository(repo);

        // Act
        var result = await sut.GetByIdAsync(itemId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldGetAllCourses()
    {
        // Arrange
        var Courses = new List<Course>()
        {
            new Course(3, "Software Engineering"),
            new Course(4, "Journalism")
        };

        _context.Courses.AddRange(Courses);
        await _context.SaveChangesAsync();

        var repo = new Repository<Course>(_context);
        var sut = new CourseRepository(repo);

        // Act
        var result = await sut.GetAsync();

        // Assert
        Assert.Equal(Courses.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateCourse()
    {
        // Arrange
        _context.Courses.Add(new Course(5, "Geograph"));
        await _context.SaveChangesAsync();

        var toUpdateCourse = new Course(5, "Geography");

        var repo = new Repository<Course>(_context);
        var sut = new CourseRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateCourse);

        // Assert
        Assert.True(result);
    }
}