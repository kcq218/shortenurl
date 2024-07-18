using Microsoft.EntityFrameworkCore;

namespace URLShortener.Models;

public partial class DbAll01ProdUswest001Context : DbContext
{
  private string _connString;
  public DbAll01ProdUswest001Context()
  {
    _connString = Environment.GetEnvironmentVariable("cs-urlshortener");
  }

  public DbAll01ProdUswest001Context(DbContextOptions<DbAll01ProdUswest001Context> options)
      : base(options)
  {
  }

  public virtual DbSet<GeneratedKey> GeneratedKeys { get; set; }

  public virtual DbSet<UrlMapping> UrlMappings { get; set; }

  public virtual DbSet<UserInfo> UserInfos { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseSqlServer(_connString);

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<GeneratedKey>(entity =>
    {
      entity.ToTable("generated_keys", "url_shortener");
      entity.Property(e => e.Id)
          .HasComment("pk incremental int")
          .HasColumnName("id");
      entity.Property(e => e.Active)
          .HasDefaultValue(true)
          .HasColumnName("active");
      entity.Property(e => e.CreatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("created_by");
      entity.Property(e => e.CreatedDate).HasColumnName("created_date");
      entity.Property(e => e.HashValue)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("hash_value");
      entity.Property(e => e.UpdatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("updated_by");
      entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
      entity.Property(e => e.UrlId).HasColumnName("url_id");
    });

    modelBuilder.Entity<UrlMapping>(entity =>
    {
      entity.ToTable("url_mapping", "url_shortener");
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Active)
          .HasDefaultValue(true)
          .HasColumnName("active");
      entity.Property(e => e.CreatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("created_by");
      entity.Property(e => e.CreatedDate).HasColumnName("created_date");
      entity.Property(e => e.HashValue)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("hash_value");
      entity.Property(e => e.KeyId).HasColumnName("key_id");
      entity.Property(e => e.LastAccessed).HasColumnName("last_accessed");
      entity.Property(e => e.LongUrl).HasColumnName("long_url");
      entity.Property(e => e.UpdatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("updated_by");
      entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
      entity.Property(e => e.UserId).HasColumnName("user_id");
    });

    modelBuilder.Entity<UserInfo>(entity =>
    {
      entity.ToTable("user_info", "url_shortener");
      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Active)
          .HasDefaultValue(true)
          .HasColumnName("active");
      entity.Property(e => e.CreatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("created_by");
      entity.Property(e => e.CreatedDate).HasColumnName("created_date");
      entity.Property(e => e.Email)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("email");
      entity.Property(e => e.FirstName)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("first_name");
      entity.Property(e => e.LastLogin).HasColumnName("last_login");
      entity.Property(e => e.LastName)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("last_name");
      entity.Property(e => e.MiddleInitial)
          .HasMaxLength(1)
          .IsUnicode(false)
          .IsFixedLength()
          .HasColumnName("middle_initial");
      entity.Property(e => e.UpdatedBy)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("updated_by");
      entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}