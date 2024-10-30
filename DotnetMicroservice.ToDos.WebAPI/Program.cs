using DotnetMicroservice.ToDos.WebAPI.Context;
using DotnetMicroservice.ToDos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("ToDosDb");
});

var app = builder.Build();

app.MapPost("/todos/create", (ApplicationDbContext context, string work) =>
{
    ToDo toDo = new ToDo();
    toDo.Work = work;
    context.Add(toDo);
    var res = context.SaveChanges();
    return res;
});

app.MapGet("/todos/getall", (ApplicationDbContext context) =>
{
    var todos = context.ToDos.ToList();
    return todos;
});

app.Run();
