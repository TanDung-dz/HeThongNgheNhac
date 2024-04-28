using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HeThongNgheNhac.Models;

public partial class HeThongNgeNhacContext : DbContext
{
    public HeThongNgeNhacContext()
    {
    }

    public HeThongNgeNhacContext(DbContextOptions<HeThongNgeNhacContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminPlayList> AdminPlayLists { get; set; }

    public virtual DbSet<AdminPlayListDetail> AdminPlayListDetails { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Music> Musics { get; set; }

    public virtual DbSet<MusicType> MusicTypes { get; set; }

    public virtual DbSet<Mv> Mvs { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<SlideShow> SlideShows { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPlayList> UserPlayLists { get; set; }

    public virtual DbSet<UserPlayListDetail> UserPlayListDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-79UVCQ2;Database=HeThongNgeNhac;Trusted_Connection=True;TrustServerCertificate= true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin);

            entity.ToTable("Admin");

            entity.Property(e => e.IdAdmin)
                .ValueGeneratedNever()
                .HasColumnName("Id_Admin");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PassWord)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminPlayList>(entity =>
        {
            entity.HasKey(e => e.IdPlayListAdmin);

            entity.ToTable("Admin_PlayList");

            entity.Property(e => e.IdPlayListAdmin)
                .ValueGeneratedNever()
                .HasColumnName("Id_PlayListAdmin");
            entity.Property(e => e.CreateDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Create_date");
            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.AdminPlayLists)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Admin_PlayList_Admin");
        });

        modelBuilder.Entity<AdminPlayListDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdPlayListAdmin, e.IdMusic });

            entity.ToTable("AdminPlayList_Details");

            entity.Property(e => e.IdPlayListAdmin).HasColumnName("Id_PlayListAdmin");
            entity.Property(e => e.IdMusic).HasColumnName("Id_Music");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Link).HasMaxLength(255);

            entity.HasOne(d => d.IdMusicNavigation).WithMany(p => p.AdminPlayListDetails)
                .HasForeignKey(d => d.IdMusic)
                .HasConstraintName("FK_AdminPlayList_Details_Music");

            entity.HasOne(d => d.IdPlayListAdminNavigation).WithMany(p => p.AdminPlayListDetails)
                .HasForeignKey(d => d.IdPlayListAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminPlayList_Details_Admin_PlayList");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor);

            entity.ToTable("Author");

            entity.Property(e => e.IdAuthor)
                .ValueGeneratedNever()
                .HasColumnName("Id_Author");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.History).HasMaxLength(500);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(50);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.IdBlog);

            entity.ToTable("Blog");

            entity.Property(e => e.IdBlog)
                .ValueGeneratedNever()
                .HasColumnName("Id_Blog");
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Titile).HasMaxLength(255);
            entity.Property(e => e.WriteDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Write_Date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Blog_User");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu)
                .ValueGeneratedNever()
                .HasColumnName("Id_Menu");
            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Menu_Admin");
        });

        modelBuilder.Entity<Music>(entity =>
        {
            entity.HasKey(e => e.IdMusic);

            entity.ToTable("Music");

            entity.Property(e => e.IdMusic)
                .ValueGeneratedNever()
                .HasColumnName("Id_Music");
            entity.Property(e => e.CountListened).HasColumnName("Count_Listened");
            entity.Property(e => e.File)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.IdAuthor).HasColumnName("Id_Author");
            entity.Property(e => e.IdMusictype).HasColumnName("Id_Musictype");
            entity.Property(e => e.IdSinger).HasColumnName("Id_Singer");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Lyric).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PublishDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Publish_Date");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Music_Admin");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Music_Author");

            entity.HasOne(d => d.IdMusictypeNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdMusictype)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Music_MusicType");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdSinger)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Music_Singer");
        });

        modelBuilder.Entity<MusicType>(entity =>
        {
            entity.HasKey(e => e.IdMusicType);

            entity.ToTable("MusicType");

            entity.Property(e => e.IdMusicType)
                .ValueGeneratedNever()
                .HasColumnName("Id_MusicType");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Mv>(entity =>
        {
            entity.HasKey(e => e.IdMv);

            entity.ToTable("MV");

            entity.Property(e => e.IdMv)
                .ValueGeneratedNever()
                .HasColumnName("Id_MV");
            entity.Property(e => e.CountView).HasColumnName("Count_view");
            entity.Property(e => e.IdSinger).HasColumnName("Id_Singer");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PublishDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Publish_date");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Mvs)
                .HasForeignKey(d => d.IdSinger)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MV_Singer");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.IdSinger);

            entity.ToTable("Singer");

            entity.Property(e => e.IdSinger)
                .ValueGeneratedNever()
                .HasColumnName("Id_Singer");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Cover_img");
            entity.Property(e => e.History).HasMaxLength(500);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Nationallity).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(50);
        });

        modelBuilder.Entity<SlideShow>(entity =>
        {
            entity.HasKey(e => e.IdSlideShow);

            entity.ToTable("SlideShow");

            entity.Property(e => e.IdSlideShow)
                .ValueGeneratedNever()
                .HasColumnName("Id_SlideShow");
            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Text).HasMaxLength(255);

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.SlideShows)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SlideShow_Admin");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("Id_User");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserPlayList>(entity =>
        {
            entity.HasKey(e => e.IdPlayListUser);

            entity.ToTable("User_PlayList");

            entity.Property(e => e.IdPlayListUser)
                .ValueGeneratedNever()
                .HasColumnName("Id_PlayListUser");
            entity.Property(e => e.CreateDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Create_date");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserPlayLists)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_PlayList_User");
        });

        modelBuilder.Entity<UserPlayListDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdMusic, e.IdPlayListUser });

            entity.ToTable("UserPlayList_Details");

            entity.Property(e => e.IdMusic).HasColumnName("Id_Music");
            entity.Property(e => e.IdPlayListUser).HasColumnName("Id_PlayListUser");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.Order)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdMusicNavigation).WithMany(p => p.UserPlayListDetails)
                .HasForeignKey(d => d.IdMusic)
                .HasConstraintName("FK_UserPlayList_Details_Music");

            entity.HasOne(d => d.IdPlayListUserNavigation).WithMany(p => p.UserPlayListDetails)
                .HasForeignKey(d => d.IdPlayListUser)
                .HasConstraintName("FK_UserPlayList_Details_User_PlayList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
