using Microsoft.EntityFrameworkCore;
using NetCore_Data.DataModels;

namespace NetCore_Services.Data;

public class CodeFirstDbContext : DbContext
{
    // 생성자 상속
    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    
    // 메서드 상속, 부모 클래스에서 OnModelCreating 메서드가 virtual
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRolesByUser>()
            .HasKey(user => new { user.UserId, user.RoleId });

        modelBuilder.Entity<User>().HasIndex(c => new { c.UserEmail });
    }
}