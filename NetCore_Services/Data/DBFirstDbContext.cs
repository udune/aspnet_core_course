using Microsoft.EntityFrameworkCore;

namespace NetCore_Services.Data;

public class DBFirstDbContext : DbContext
{
    public DBFirstDbContext(DbContextOptions<DBFirstDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}