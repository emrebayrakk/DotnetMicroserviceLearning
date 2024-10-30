using DotnetMicroservice.Categories.WebAPI.Context;
using DotnetMicroservice.Categories.WebAPI.Dtos;
using DotnetMicroservice.Categories.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

var app = builder.Build();

app.MapGet("/categories/getall", async (ApplicationDbContext context,CancellationToken cancellationToken) =>
{
    var res = await context.Categories.ToListAsync();
    return res;
});

app.MapPost("/categories/create", async (ApplicationDbContext context, CancellationToken cancellationToken,CategoryDto cat) =>
{

    bool isNameExist = await context.Categories.AnyAsync(c => c.Name == cat.name);
    if (isNameExist)
    {
        return Results.BadRequest(new { Message = "Already Exist!" });
    }

    Category category = new()
    {
        Name = cat.name
    };
    await context.AddAsync(category);
    var res = await context.SaveChangesAsync();
    return Results.Ok(new { Message = "Added Category" });
});

app.Run();
