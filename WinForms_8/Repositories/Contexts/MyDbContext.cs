using Microsoft.EntityFrameworkCore;
using WinForms_8.Models;

using Microsoft.Extensions.Configuration;

namespace WinForms_8.Repositories.Contexts;


public class MyDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionStr = configuration.GetConnectionString("DefaultConStr");

        optionsBuilder.UseSqlServer(connectionStr);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Student>? Students { get; set; }

}