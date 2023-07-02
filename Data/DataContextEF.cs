using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  public class DataContextEF : DbContext
  {
    // private IConfiguration _config;
    private string? _connectionString;
    public DataContextEF(IConfiguration config)
    {
      // _config = config;
      _connectionString = config.GetConnectionString("DefaultConnection");
    }
    public DbSet<Computer>? Computer { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure());
      }
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("TutorialAppSchema");
      modelBuilder.Entity<Computer>()
      // .HasNoKey();
      .HasKey(computer => computer.ComputerId);
      // .ToTable("Computer", "TutorialAppSchema");
      // .ToTable("TableName", "SchemaName");

    }
  };
}