using Microsoft.EntityFrameworkCore;
using SchoolSchedule.API.Profiles;
using SchoolSchedule.BusinessLogic.Services.Implemantation;
using SchoolSchedule.BusinessLogic.Services.Implementation;
using SchoolSchedule.BusinessLogic.Services.Interfaces;
using SchoolSchedule.DataAccess.Data;
using SchoolSchedule.DataAccess.Repositories.Implementations;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection"));
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentGroupService, StudentGroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

builder.Services.AddAutoMapper(typeof(StudentGroupProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
