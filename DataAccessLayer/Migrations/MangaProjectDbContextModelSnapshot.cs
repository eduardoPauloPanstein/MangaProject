﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(MangaProjectDbContext))]
    partial class MangaProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.MangaS.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ApiID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MangaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MangaId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.Manga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgeRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgeRatingGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apiids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AverageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CanonicalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavoritesCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PopularityRank")
                        .HasColumnType("int");

                    b.Property<string>("PosterImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RatingFrequenciesId")
                        .HasColumnType("int");

                    b.Property<int?>("RatingRank")
                        .HasColumnType("int");

                    b.Property<string>("Serialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TitlesId")
                        .HasColumnType("int");

                    b.Property<int?>("UserCount")
                        .HasColumnType("int");

                    b.Property<int?>("VolumeCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RatingFrequenciesId");

                    b.HasIndex("TitlesId");

                    b.ToTable("Mangas", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.MangaTitles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("En_jp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("En_us")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ja_jp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MangaTitles", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.RatingFrequencies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MangasRatingFrequencies", (string)null);
                });

            modelBuilder.Entity("Entities.UserS.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImageFileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageFileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("FavoritesCount")
                        .HasColumnType("int");

                    b.Property<bool>("KeepLogged")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewsCount")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Entities.UserS.UserMangaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<string>("PrivateNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalRereads")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMangaItem", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.Category", b =>
                {
                    b.HasOne("Entities.MangaS.Manga", null)
                        .WithMany("Categoria")
                        .HasForeignKey("MangaId");
                });

            modelBuilder.Entity("Entities.MangaS.Manga", b =>
                {
                    b.HasOne("Entities.MangaS.RatingFrequencies", "RatingFrequencies")
                        .WithMany()
                        .HasForeignKey("RatingFrequenciesId");

                    b.HasOne("Entities.MangaS.MangaTitles", "Titles")
                        .WithMany()
                        .HasForeignKey("TitlesId");

                    b.Navigation("RatingFrequencies");

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("Entities.UserS.UserMangaItem", b =>
                {
                    b.HasOne("Entities.MangaS.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.UserS.User", "User")
                        .WithMany("MangaList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_mangauser");

                    b.Navigation("Manga");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.MangaS.Manga", b =>
                {
                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Entities.UserS.User", b =>
                {
                    b.Navigation("MangaList");
                });
#pragma warning restore 612, 618
        }
    }
}
