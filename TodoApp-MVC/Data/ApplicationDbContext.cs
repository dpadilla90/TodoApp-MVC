using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    // Represents the database context for the application, which allows interaction with the underlying database.
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter and passes it to the base class constructor.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet property representing the collection of ToDo items in the database.
        // This property allows CRUD (Create, Read, Update, Delete) operations on the ToDo items table.
        // It enables you to query and manipulate ToDo data using LINQ and Entity Framework Core.
        public DbSet<ToDo> ToDos { get; set; }
    }
}