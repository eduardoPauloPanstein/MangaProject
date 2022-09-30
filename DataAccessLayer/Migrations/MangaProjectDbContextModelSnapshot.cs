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

            modelBuilder.Entity("AnimeCategory", b =>
                {
                    b.Property<int>("AnimesIDId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesID")
                        .HasColumnType("int");

                    b.HasKey("AnimesIDId", "CategoriesID");

                    b.HasIndex("CategoriesID");

                    b.ToTable("AnimeCategory");
                });

            modelBuilder.Entity("CategoryManga", b =>
                {
                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<int>("MangasIDId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaID", "MangasIDId");

                    b.HasIndex("MangasIDId");

                    b.ToTable("CategoryManga");
                });

            modelBuilder.Entity("Entities.AnimeS.Anime", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AnimeCoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimePosterImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AnimeRatingFrequenciesId")
                        .HasColumnType("int");

                    b.Property<int?>("AnimeTitlesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ageRatingGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("averageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("canonicalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("episodeCount")
                        .HasColumnType("int");

                    b.Property<int?>("episodeLength")
                        .HasColumnType("int");

                    b.Property<int?>("favoritesCount")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("popularityRank")
                        .HasColumnType("int");

                    b.Property<int?>("ratingRank")
                        .HasColumnType("int");

                    b.Property<string>("showType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("subtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("totalLength")
                        .HasColumnType("int");

                    b.Property<int?>("userCount")
                        .HasColumnType("int");

                    b.Property<string>("youtubeVideoId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimeRatingFrequenciesId");

                    b.HasIndex("AnimeTitlesId");

                    b.ToTable("Anime", (string)null);
                });

            modelBuilder.Entity("Entities.AnimeS.AnimeComentary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<string>("Comentary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataComentary")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserId");

                    b.ToTable("AnimeComentary", (string)null);
                });

            modelBuilder.Entity("Entities.AnimeS.AnimeRatingFrequencies", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("_1")
                        .HasColumnType("int");

                    b.Property<int?>("_2")
                        .HasColumnType("int");

                    b.Property<int?>("_3")
                        .HasColumnType("int");

                    b.Property<int?>("_4")
                        .HasColumnType("int");

                    b.Property<int?>("_5")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnimeRatingFrequencies", (string)null);
                });

            modelBuilder.Entity("Entities.AnimeS.AnimeSTitles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("En_jp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ja_jp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimeSTitles");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.Manga", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AverageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CanonicalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavoritesCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserCount")
                        .HasColumnType("int");

                    b.Property<int?>("VolumeCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RatingFrequenciesId");

                    b.HasIndex("TitlesId");

                    b.ToTable("Mangas", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.MangaComentary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataComentary")
                        .HasColumnType("datetime2");

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.HasIndex("UserId");

                    b.ToTable("MangaComentary", (string)null);
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

                    b.Property<string>("Ja_jp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MangaTitles", (string)null);
                });

            modelBuilder.Entity("Entities.MangaS.RatingFrequencies", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("_1")
                        .HasColumnType("int");

                    b.Property<int?>("_2")
                        .HasColumnType("int");

                    b.Property<int?>("_3")
                        .HasColumnType("int");

                    b.Property<int?>("_4")
                        .HasColumnType("int");

                    b.Property<int?>("_5")
                        .HasColumnType("int");

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

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AvatarImageFileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageFileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
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

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Entities.UserS.UserAnimeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int?>("Chapter")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<string>("PrivateNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TotalRereads")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnimeItem", (string)null);
                });

            modelBuilder.Entity("Entities.UserS.UserMangaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("Chapter")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<string>("PrivateNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TotalRereads")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMangaItem", (string)null);
                });

            modelBuilder.Entity("AnimeCategory", b =>
                {
                    b.HasOne("Entities.AnimeS.Anime", null)
                        .WithMany()
                        .HasForeignKey("AnimesIDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryManga", b =>
                {
                    b.HasOne("Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.MangaS.Manga", null)
                        .WithMany()
                        .HasForeignKey("MangasIDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.AnimeS.Anime", b =>
                {
                    b.HasOne("Entities.AnimeS.AnimeRatingFrequencies", "AnimeRatingFrequencies")
                        .WithMany()
                        .HasForeignKey("AnimeRatingFrequenciesId");

                    b.HasOne("Entities.AnimeS.AnimeSTitles", "AnimeTitles")
                        .WithMany()
                        .HasForeignKey("AnimeTitlesId");

                    b.Navigation("AnimeRatingFrequencies");

                    b.Navigation("AnimeTitles");
                });

            modelBuilder.Entity("Entities.AnimeS.AnimeComentary", b =>
                {
                    b.HasOne("Entities.AnimeS.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.UserS.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");
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

            modelBuilder.Entity("Entities.MangaS.MangaComentary", b =>
                {
                    b.HasOne("Entities.MangaS.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.UserS.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manga");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.UserS.UserAnimeItem", b =>
                {
                    b.HasOne("Entities.AnimeS.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.UserS.User", "User")
                        .WithMany("AnimeList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Animeuser");

                    b.Navigation("Anime");

                    b.Navigation("User");
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

            modelBuilder.Entity("Entities.UserS.User", b =>
                {
                    b.Navigation("AnimeList");

                    b.Navigation("MangaList");
                });
#pragma warning restore 612, 618
        }
    }
}
