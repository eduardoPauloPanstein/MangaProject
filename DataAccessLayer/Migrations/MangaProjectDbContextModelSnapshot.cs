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

            modelBuilder.Entity("Entities.Manga.Manga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgeRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgeRatingGuide")
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

            modelBuilder.Entity("Entities.Manga.MangaTitles", b =>
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

            modelBuilder.Entity("Entities.Manga.RatingFrequencies", b =>
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

            modelBuilder.Entity("Entities.User", b =>
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
                        .HasColumnType("date");

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
                        .HasColumnType("date");

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

            modelBuilder.Entity("Entities.Manga.Manga", b =>
                {
                    b.HasOne("Entities.Manga.RatingFrequencies", "RatingFrequencies")
                        .WithMany()
                        .HasForeignKey("RatingFrequenciesId");

                    b.HasOne("Entities.Manga.MangaTitles", "Titles")
                        .WithMany()
                        .HasForeignKey("TitlesId");

                    b.Navigation("RatingFrequencies");

                    b.Navigation("Titles");
                });
#pragma warning restore 612, 618
        }
    }
}
