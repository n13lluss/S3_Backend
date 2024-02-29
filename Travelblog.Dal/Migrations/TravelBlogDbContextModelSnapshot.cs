﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travelblog.Dal;

#nullable disable

namespace Travelblog.Dal.Migrations
{
    [DbContext(typeof(TravelBlogDbContext))]
    partial class TravelBlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Travelblog.Dal.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("Creator_Id");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Prive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Start_Date");

                    b.Property<bool>("Suspended")
                        .HasColumnType("bit");

                    b.Property<int?>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TripId");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogCountry", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_Id");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("Country_Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CountryId");

                    b.ToTable("Blog/Country", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogFollower", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_Id");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int")
                        .HasColumnName("Follower_Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Blog/Follower", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogLike", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_Id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Blog/Like", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogPost", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_Id");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("PostId");

                    b.ToTable("Blog/Post", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogTag", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_Id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("Tag_Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagId");

                    b.ToTable("Blog/Tag", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Budget", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Duration", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("Posted_On");

                    b.Property<bool>("Prive")
                        .HasColumnType("bit");

                    b.Property<bool>("Suspended")
                        .HasColumnType("bit");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostCountry", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("Country_Id");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PostId");

                    b.ToTable("Post/Country", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostLike", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post/Like", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostReaction", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int")
                        .HasColumnName("Reaction_Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ReactionId");

                    b.ToTable("Post/Reaction", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostTag", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("Tag_Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("Post/Tag", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Theme")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Preference", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Post_Date");

                    b.Property<bool>("Prive")
                        .HasColumnType("bit");

                    b.Property<bool>("Suspended")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reaction", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.ReactionLike", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int")
                        .HasColumnName("Reaction_Id");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasIndex("ReactionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reaction/Like", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int")
                        .HasColumnName("Object_Id");

                    b.Property<int>("ObjectType")
                        .HasColumnType("int")
                        .HasColumnName("Object_Type");

                    b.Property<int>("ReporterId")
                        .HasColumnType("int")
                        .HasColumnName("Reporter_Id");

                    b.Property<int?>("ResolverId")
                        .HasColumnType("int")
                        .HasColumnName("Resolver_Id");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ReporterId");

                    b.HasIndex("ResolverId");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Transport", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("Creator_Id");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("Posted_On");

                    b.Property<bool>("Prive")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("Start_Date");

                    b.Property<bool>("Suspended")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Trip", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripBudget", b =>
                {
                    b.Property<int>("BudgetId")
                        .HasColumnType("int")
                        .HasColumnName("Budget_Id");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("TripId");

                    b.ToTable("Trip/Budget", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripCountry", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("Country_Id");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("TripId");

                    b.ToTable("Trip/Country", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripDuration", b =>
                {
                    b.Property<int>("DurationId")
                        .HasColumnType("int")
                        .HasColumnName("Duration_Id");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasIndex("DurationId");

                    b.HasIndex("TripId");

                    b.ToTable("Trip/Duration", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("Tag_Id");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TripId");

                    b.ToTable("Trip/Tag", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripTransport", b =>
                {
                    b.Property<int>("TransportId")
                        .HasColumnType("int")
                        .HasColumnName("Transport_Id");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("Trip_Id");

                    b.HasIndex("TransportId");

                    b.HasIndex("TripId");

                    b.ToTable("Trip/Transport", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Suspended")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Blog", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.User", "Creator")
                        .WithMany("Blogs")
                        .HasForeignKey("CreatorId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog_User");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany("Blogs")
                        .HasForeignKey("TripId")
                        .HasConstraintName("FK_Blog_Trip");

                    b.Navigation("Creator");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogCountry", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Country_Blog");

                    b.HasOne("Travelblog.Dal.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Country_Country");

                    b.Navigation("Blog");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogFollower", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Follower_Blog");

                    b.HasOne("Travelblog.Dal.Entities.User", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Follower_User");

                    b.Navigation("Blog");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogLike", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Like_Blog");

                    b.HasOne("Travelblog.Dal.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Like_User");

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogPost", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Post_Blog");

                    b.HasOne("Travelblog.Dal.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Post_Post");

                    b.Navigation("Blog");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.BlogTag", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Tag_Blog");

                    b.HasOne("Travelblog.Dal.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_Blog/Tag_Tag");

                    b.Navigation("Blog");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Post", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany("Posts")
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Post_Trip");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostCountry", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Country_Country");

                    b.HasOne("Travelblog.Dal.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Country_Post");

                    b.Navigation("Country");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostLike", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Like_Post");

                    b.HasOne("Travelblog.Dal.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Like_User");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostReaction", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Reaction_Post");

                    b.HasOne("Travelblog.Dal.Entities.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Reaction_Reaction");

                    b.Navigation("Post");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.PostTag", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Tag_Post");

                    b.HasOne("Travelblog.Dal.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_Post/Tag_Tag");

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Preference", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.User", "User")
                        .WithMany("Preferences")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Preference_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Reaction", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Reaction_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.ReactionLike", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .IsRequired()
                        .HasConstraintName("FK_Reaction/Like_Reaction");

                    b.HasOne("Travelblog.Dal.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Reaction/Like_User");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Report", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.User", "Reporter")
                        .WithMany("ReportReporters")
                        .HasForeignKey("ReporterId")
                        .IsRequired()
                        .HasConstraintName("FK_Report_User");

                    b.HasOne("Travelblog.Dal.Entities.User", "Resolver")
                        .WithMany("ReportResolvers")
                        .HasForeignKey("ResolverId")
                        .HasConstraintName("FK_Report_User1");

                    b.Navigation("Reporter");

                    b.Navigation("Resolver");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Trip", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.User", "Creator")
                        .WithMany("Trips")
                        .HasForeignKey("CreatorId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip_User");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripBudget", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Budget_Budget");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Budget_Trip");

                    b.Navigation("Budget");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripCountry", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Country_Country");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Country_Trip");

                    b.Navigation("Country");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripDuration", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Duration", "Duration")
                        .WithMany()
                        .HasForeignKey("DurationId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Duration_Duration");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Duration_Trip");

                    b.Navigation("Duration");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripTag", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Tag_Tag");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Tag_Trip");

                    b.Navigation("Tag");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.TripTransport", b =>
                {
                    b.HasOne("Travelblog.Dal.Entities.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Transport_Transport");

                    b.HasOne("Travelblog.Dal.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip/Transport_Trip");

                    b.Navigation("Transport");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.Trip", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Travelblog.Dal.Entities.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Preferences");

                    b.Navigation("Reactions");

                    b.Navigation("ReportReporters");

                    b.Navigation("ReportResolvers");

                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
