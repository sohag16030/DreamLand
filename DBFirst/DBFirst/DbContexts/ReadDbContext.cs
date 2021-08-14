using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBFirst.Models.Read;

#nullable disable

namespace DBFirst.DbContexts
{
    public partial class ReadDbContext : DbContext
    {
        public ReadDbContext()
        {
        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblComment> TblComment { get; set; }
        public virtual DbSet<TblLike> TblLike { get; set; }
        public virtual DbSet<TblPost> TblPost { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T5RMSEA;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblComment>(entity =>
            {
                entity.HasKey(e => e.IntCommentId);

                entity.ToTable("tblComment");

                entity.Property(e => e.IntCommentId).HasColumnName("intCommentId");

                entity.Property(e => e.IntPostId).HasColumnName("intPostId");

                entity.Property(e => e.IntUserId).HasColumnName("intUserId");

                entity.Property(e => e.StrCommentDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strCommentDescription");

                entity.HasOne(d => d.IntPost)
                    .WithMany(p => p.TblComment)
                    .HasForeignKey(d => d.IntPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComment_tblPost1");

                entity.HasOne(d => d.IntUser)
                    .WithMany(p => p.TblComment)
                    .HasForeignKey(d => d.IntUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComment_tblUser");
            });

            modelBuilder.Entity<TblLike>(entity =>
            {
                entity.HasKey(e => e.IntLikeId);

                entity.ToTable("tblLike");

                entity.Property(e => e.IntLikeId).HasColumnName("intLikeId");

                entity.Property(e => e.IntPostId).HasColumnName("intPostId");

                entity.Property(e => e.IntUserId).HasColumnName("intUserId");

                entity.HasOne(d => d.IntPost)
                    .WithMany(p => p.TblLike)
                    .HasForeignKey(d => d.IntPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLike_tblPost");

                entity.HasOne(d => d.IntUser)
                    .WithMany(p => p.TblLike)
                    .HasForeignKey(d => d.IntUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLike_tblUser");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasKey(e => e.IntPostId);

                entity.ToTable("tblPost");

                entity.Property(e => e.IntPostId).HasColumnName("intPostId");

                entity.Property(e => e.IntUserId).HasColumnName("intUserId");

                entity.Property(e => e.StrPostDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strPostDescription");

                entity.HasOne(d => d.IntUser)
                    .WithMany(p => p.TblPost)
                    .HasForeignKey(d => d.IntUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPost_tblUser");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IntUserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.IntUserId).HasColumnName("intUserId");

                entity.Property(e => e.StrUserName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strUserName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
