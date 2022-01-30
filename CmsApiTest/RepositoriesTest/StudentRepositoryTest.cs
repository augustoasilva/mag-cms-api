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

public class StudentRepositoryTest
{
    private readonly DataContext _context;

    public StudentRepositoryTest()
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );
        
        _context = new DataContext(dbOptions.Options);
    }

    [Fact]
    public async Task ShouldAddStudent()
    {
        // Arrange
        var repo = new Repository<Student>(_context);
        var sut = new StudentRepository(repo);
        var item = new Student(1, "Ana", "Silva", new DateTime(2000,11,05), 1);
            
        // Act
        var result = await sut.AddAsync(item);
            
        // Assert
        var items = _context.Students.ToList();
        Assert.True(result);
        Assert.Single(items);
    }
    
    [Fact]
    public async Task ShouldGetStudent() {
        // Arrange
        const int itemId = 2;
        _context.Students.Add(new Student(2, "Fernando", "Montero", new DateTime(2000, 11, 05), 1));
        await _context.SaveChangesAsync();

        var repo = new Repository<Student>(_context);
        var sut = new StudentRepository(repo);
            
        // Act
        var result = await sut.GetByIdAsync(itemId);
            
        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task ShouldGetAllStudents() {
        // Arrange
        var students = new List<Student>() {
            new Student(3, "Guilherme", "Sousa", new DateTime(2000,11,05), 1),
            new Student(4, "Milton", "Nunes", new DateTime(2000,11,05), 1)
        };
            
        _context.Students.AddRange(students);
        await _context.SaveChangesAsync();
            
        var repo = new Repository<Student>(_context);
        var sut = new StudentRepository(repo);

        // Act
        var result = await sut.GetAsync();
            
        // Assert
        Assert.Equal(students.Count, result.Count());
    }

    [Fact]
    public async Task ShouldUpdateStudent() {
        // Arrange
        _context.Students.Add(new Student(5, "Alberto", "Silveira", new DateTime(2000,11,05), 1));
        await _context.SaveChangesAsync();

        var toUpdateStudent = new Student(5, "Alberto", "Mendes", new DateTime(2000, 11, 05), 1);

        var repo = new Repository<Student>(_context);
        var sut = new StudentRepository(repo);
        // Act
        var result = await sut.AddAsync(toUpdateStudent);
        
        // Assert
        Assert.True(result);
    }
}
