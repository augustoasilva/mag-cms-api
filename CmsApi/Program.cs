using CmsApi.Data;
using CmsApi.Models;
using CmsApi.Repositories;
using CmsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(
    dbConnOpt => dbConnOpt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"))
);

builder.Services.AddControllers().AddNewtonsoftJson(
    opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();