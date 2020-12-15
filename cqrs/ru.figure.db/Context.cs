using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ru.figure.db
{
    public class FigureContext : DbContext
  {
    public DbSet<Figure> Figures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={Path.Combine(Path.GetTempPath(), "figure-cqrs.db")}");
  }

  
}
