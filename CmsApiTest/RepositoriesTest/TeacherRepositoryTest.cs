using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CmsApi.Data;
using CmsApi.Models;
using CmsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CmsApiTest.RepositoriesTest;

public class TeacherRepositoryTest
{
    private readonly DataContext _context;

    public TeacherRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );
        
        _context = new DataContext(dbOptions.Options);
    }
    
    [Fact]
    public async Task ShouldAddTeacher()
    {
        // Arrange
        var repo = new Repository<Teacher>(_context);
        var sut = new TeacherRepository(repo);
        var item = new Teacher(1, "Lauro", "Alvarez", new DateTime(1980,11,05), new decimal(1500.00));
            
        // Act
        var result = await sut.AddAsync(item);
            
        // Assert
        var items = _context.Teachers.ToList();
        Assert.True(result);
        Assert.Single(items);
    }
    
    [Fact]
    public async Task ShouldGetTeacher() {
        // Arrange
        const int itemId = 2;
        _context.Teachers.Add(new Teacher(2, "Roberto", "Hernandez", new DateTime(1985,07,14), new decimal(1600.00)));
        await _context.SaveChangesAsync();

        var repo = new Repository<Teacher>(_context);
        var sut = new TeacherRepository(repo);
            
        // Act
        var result = await sut.GetByIdAsync(itemId);
            
        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task ShouldGetAllTeachers() {
        // Arrange
        var Teachers = new List<Teacher>() {
            new Teacher(3, "Ronaldo", "Silva", new DateTime(1990,02,25), new decimal(1700.00)),
            new Teacher(4, "Rodrigo", "Wilhelm", new DateTime(1989,03,27), new decimal(1800.00))
        };
            
        _context.Teachers.AddRange(Teachers);
        await _context.SaveChangesAsync();
            
        var repo = new Repository<Teacher>(_context);
        var sut = new TeacherRepository(repo);

        // Act
        var result = await sut.GetAsync();
            
        // Assert
        Assert.Equal(Teachers.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateTeacher() {
        // Arrange
        _context.Teachers.Add(new Teacher(5, "Pedro", "Lobo", new DateTime(1992,01,10), new decimal(1900.00)));
        await _context.SaveChangesAsync();

        var toUpdateTeacher = new Teacher(5, "Alberto", "Lobo", new DateTime(1992,01,10), new decimal(1900.00));

        var repo = new Repository<Teacher>(_context);
        var sut = new TeacherRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateTeacher);
        
        // Assert
        Assert.True(result);
    }
}