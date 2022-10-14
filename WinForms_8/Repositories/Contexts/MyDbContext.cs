using Microsoft.EntityFrameworkCore;
using WinForms_8.Models;

namespace WinForms_8.Repositories.Contexts;


public class MyDbContext : DbContext
{

    // Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = 'DemoMVP'; Integrated Security = True;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = DemoMVP; Integrated Security = True;");

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Student> Students { get; set; }

}