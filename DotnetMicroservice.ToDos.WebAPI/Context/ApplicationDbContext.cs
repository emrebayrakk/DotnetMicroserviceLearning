using DotnetMicroservice.ToDos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetMicroservice.ToDos.WebAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
