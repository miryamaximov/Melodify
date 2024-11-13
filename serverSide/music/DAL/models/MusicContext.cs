using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.models;

public partial class MusicContext : DbContext
{
    public MusicContext()
    {
    }

    public MusicContext(DbContextOptions<MusicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumsDetail> AlbumsDetails { get; set; }

    public virtual DbSet<CategoriesDetail> CategoriesDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Follower> Followers { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistsDetail> PlaylistsDetails { get; set; }

    public virtual DbSet<SharedPlaylistsDetail> SharedPlaylistsDetails { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= .;Database= Music;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__Albums__97B4BE37D11CAD68");

            entity.Property(e => e.AlbumName).HasMaxLength(20);
            entity.Property(e => e.ImageUrl).HasMaxLength(50);

            entity.HasOne(d => d.AlbumSingerNavigation).WithMany(p => p.Albums)
                .HasForeignKey(d => d.AlbumSingerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Albums__AlbumSin__38996AB5");
        });

        modelBuilder.Entity<AlbumsDetail>(entity =>
        {
            entity.HasKey(e => e.AlbumsDetailsId).HasName("PK__AlbumsDe__31AF321F869D1F24");

            entity.HasOne(d => d.Album).WithMany()
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlbumsDet__Album__3A81B327");

            entity.HasOne(d => d.Song).WithMany()
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlbumsDet__SongI__3B75D760");
        });

        modelBuilder.Entity<CategoriesDetail>(entity =>
        {
            entity.HasKey(e => e.CategoriesDetailsId).HasName("PK__Categori__E1A4298B14E8BC5D");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Categorie__Categ__31EC6D26");

            entity.HasOne(d => d.Song).WithMany()
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Categorie__SongI__32E0915F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B505A8972");

            entity.Property(e => e.CategoryName).HasMaxLength(20);
        });

        modelBuilder.Entity<Follower>(entity =>
        {
            entity.HasKey(e => e.FollowerId).HasName("PK__Follower__E85940194332010C");

            entity.HasOne(d => d.Singer).WithMany()
                .HasForeignKey(d => d.SingerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Followers__Singe__34C8D9D1");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Followers__UserI__35BCFE0A");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId).HasName("PK__Playlist__B30167A0218232F0");

            entity.Property(e => e.ProductionDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Playlists__UserI__2D27B809");
        });

        modelBuilder.Entity<PlaylistsDetail>(entity =>
        {
            entity.HasKey(e => e.PlaylistsDetailsId).HasName("PK__Playlist__3F1D3A03E27ADCE5");

            entity.HasOne(d => d.Playlist).WithMany()
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Playlists__Playl__2F10007B");

            entity.HasOne(d => d.Song).WithMany()
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Playlists__SongI__300424B4");
        });

        modelBuilder.Entity<SharedPlaylistsDetail>(entity =>
        {
            entity.HasKey(e => e.SharedPlaylistsDetailsId).HasName("PK__SharedPl__67ADF63CD5AA7E6C");

            entity.HasOne(d => d.Playlist).WithMany()
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedPla__Playl__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedPla__UserI__3E52440B");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.SingerId).HasName("PK__Singers__0E67E7AA40CAB20D");

            entity.Property(e => e.ImageUrl).HasMaxLength(50);
            entity.Property(e => e.SingerAbout).HasMaxLength(1000);
            entity.Property(e => e.SingerFirstName).HasMaxLength(10);
            entity.Property(e => e.SingerLastName).HasMaxLength(10);
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Songs__12E3D697D6FF5C98");

            entity.Property(e => e.ImageUrl).HasMaxLength(50);
            entity.Property(e => e.SongAbout).HasMaxLength(1000);
            entity.Property(e => e.SongName).HasMaxLength(20);
            entity.Property(e => e.SongUrl).HasMaxLength(50);
            entity.Property(e => e.UploadDate).HasColumnType("datetime");

            entity.HasOne(d => d.Singer).WithMany(p => p.Songs)
                .HasForeignKey(d => d.SingerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Songs__SingerId__2A4B4B5E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C0C7EAD60");

            entity.Property(e => e.UserEmail).HasMaxLength(30);
            entity.Property(e => e.UserName).HasMaxLength(20);
            entity.Property(e => e.UserPass).HasMaxLength(8);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
