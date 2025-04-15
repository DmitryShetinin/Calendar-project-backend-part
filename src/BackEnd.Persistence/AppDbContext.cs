using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace BackEnd.Persistence.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public virtual DbSet<CalendarEntity> Calendars { get; set; }
    public virtual DbSet<EventEntity> Events { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }

    private readonly IConfiguration _configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("LearningDbContext"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        // CalendarEntity
        modelBuilder.Entity<CalendarEntity>(entity =>
        {
            entity.HasKey(e => e.Calendarid).HasName("calendars_pkey");
            entity.ToTable("calendars");

            entity.Property(e => e.Calendarid)
                .HasColumnName("calendarid")
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.Property(e => e.Userid)
                .HasColumnName("userid");
        });

        // EventEntity
        modelBuilder.Entity<EventEntity>(entity =>
        {
            entity.HasKey(e => e.Event1).HasName("events_pkey");
            entity.ToTable("events");

            entity.Property(e => e.Event1)
                .HasColumnName("event1")
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Calendarid)
                .HasColumnName("calendarid");

            // Остальные свойства без изменений
        });

        // UserEntity
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");

            // Остальные свойства без изменений
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}