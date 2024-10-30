using DotnetMicroservice.Categories.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetMicroservice.Categories.WebAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
