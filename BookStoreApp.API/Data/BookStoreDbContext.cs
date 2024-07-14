using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            //entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07E4044D61");

			entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA5D6BDD3B").IsUnique();

            //entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

            entity.Property(e => e.Image).HasMaxLength(250);

            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Summary).HasMaxLength(250);

            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "5ee3a968-9685-43cc-8ee3-b2f637e75032"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "c8ee558b-4f61-4e70-baad-652277882885"

            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "af40331e-3396-4a74-8495-de0d70eed889",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "8bea7983-d3cf-4568-98b9-7ed2ed06376e",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "5ee3a968-9685-43cc-8ee3-b2f637e75032",
                UserId = "8bea7983-d3cf-4568-98b9-7ed2ed06376e"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c8ee558b-4f61-4e70-baad-652277882885",
                UserId = "af40331e-3396-4a74-8495-de0d70eed889"
            }
        );
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}