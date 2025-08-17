using CrowdFunding.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CrowdFunding.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

 
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Donation> Donations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.FundingGoal).HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.AmountRaised).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Status)
                  .HasMaxLength(50)
                  .IsRequired();
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.HasOne(d => d.Project) 
                  .WithMany(sp => sp.Donations) 
                  .HasForeignKey(d => d.ProjectId)
                  .OnDelete(DeleteBehavior.Cascade); 
        });


        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique(); 
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.Institution).HasMaxLength(100);
            entity.Property(e => e.Bio).HasMaxLength(500);

        });

        modelBuilder.Entity<Student>()
       .HasMany(s => s.Projects)
       .WithMany(p => p.Students)
       .UsingEntity<Dictionary<string, object>>(
           "StudentProjects", // nombre de la tabla intermedia
           j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
           j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId")
       );


    }

   
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}