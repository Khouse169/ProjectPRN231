using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class ProjectPRN231Context : DbContext
    {
        public ProjectPRN231Context()
        {
        }

        public ProjectPRN231Context(DbContextOptions<ProjectPRN231Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Story> Stories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =.\\MSI; database=ProjectPRN231; uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("Chapter");

                entity.Property(e => e.ChapterId).HasColumnName("chapter_id");

                entity.Property(e => e.ChapterNumber).HasColumnName("chapter_number");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.StoryId)
                    .HasConstraintName("FK__Chapter__story_i__44FF419A");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentText)
                    .HasColumnType("text")
                    .HasColumnName("comment_text");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.StoryId)
                    .HasConstraintName("FK__Comment__story_i__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comment__user_id__47DBAE45");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.HasIndex(e => e.Name, "UQ__Genre__72E12F1BB82F0648")
                    .IsUnique();

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("Library");

                entity.Property(e => e.LibraryId).HasColumnName("library_id");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.StoryId)
                    .HasConstraintName("FK__Library__story_i__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Library__user_id__4BAC3F29");
            });

            modelBuilder.Entity<Story>(entity =>
            {
                entity.ToTable("Story");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cover_image");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.IsApproved)
                    .HasColumnName("is_approved")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publish_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Story__genre_id__4222D4EF");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__AB6E6164AD59211B")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__User__F3DBC5725B342C70")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("balance")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
