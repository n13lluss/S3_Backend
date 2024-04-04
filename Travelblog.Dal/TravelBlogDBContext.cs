using Microsoft.EntityFrameworkCore;
using Travelblog.Dal.Entities;

namespace Travelblog.Dal;

public partial class TravelBlogDbContext : DbContext
{
    public TravelBlogDbContext()
    {
    }

    public TravelBlogDbContext(DbContextOptions<TravelBlogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogCountry> BlogCountries { get; set; }

    public virtual DbSet<BlogFollower> BlogFollowers { get; set; }

    public virtual DbSet<BlogLike> BlogLikes { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    public virtual DbSet<BlogTag> BlogTags { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Duration> Durations { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCountry> PostCountries { get; set; }

    public virtual DbSet<PostLike> PostLikes { get; set; }

    public virtual DbSet<PostReaction> PostReactions { get; set; }

    public virtual DbSet<PostTag> PostTags { get; set; }

    public virtual DbSet<Preference> Preferences { get; set; }

    public virtual DbSet<Reaction> Reactions { get; set; }

    public virtual DbSet<ReactionLike> ReactionLikes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripBudget> TripBudgets { get; set; }

    public virtual DbSet<TripCountry> TripCountries { get; set; }

    public virtual DbSet<TripDuration> TripDurations { get; set; }

    public virtual DbSet<TripTag> TripTags { get; set; }

    public virtual DbSet<TripTransport> TripTransports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // DbContext is configured through DI
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.CreatorId).HasColumnName("Creator_Id");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Creator).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_User");

            entity.HasOne(d => d.Trip).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_Blog_Trip");
        });

        modelBuilder.Entity<BlogCountry>(entity =>
        {
            entity.ToTable("Blog/Country");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Country_Blog");

            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Country_Country");
        });

        modelBuilder.Entity<BlogFollower>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Blog/Follower");

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.FollowerId).HasColumnName("Follower_Id");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Follower_Blog");

            entity.HasOne(d => d.Follower).WithMany()
                .HasForeignKey(d => d.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Follower_User");
        });

        modelBuilder.Entity<BlogLike>(entity =>
        {
            entity.ToTable("Blog/Like"); // Set the table name

            entity.HasKey(e => e.Id); // Specify the primary key

            entity.Property(e => e.Id).HasColumnName("Id"); // Map the Id property to the column Id

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Like_Blog");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Like_User");
        });


        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity
                .HasKey("Id");

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.PostId).HasColumnName("Post_Id");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Post_Blog");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Post_Post");
        });

        modelBuilder.Entity<BlogTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Blog/Tag");

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.TagId).HasColumnName("Tag_Id");

            entity.HasOne(d => d.Blog).WithMany()
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Tag_Blog");

            entity.HasOne(d => d.Tag).WithMany()
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog/Tag_Tag");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("Budget");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Continent).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Duration>(entity =>
        {
            entity.ToTable("Duration");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PostedOn)
                .HasColumnType("datetime")
                .HasColumnName("Posted_On");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Trip).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Trip");
        });

        modelBuilder.Entity<PostCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post/Country");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.PostId).HasColumnName("Post_Id");

            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Country_Country");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Country_Post");
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post/Like");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("Post_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Like_Post");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Like_User");
        });

        modelBuilder.Entity<PostReaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post/Reaction");

            entity.Property(e => e.PostId).HasColumnName("Post_Id");
            entity.Property(e => e.ReactionId).HasColumnName("Reaction_Id");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Reaction_Post");

            entity.HasOne(d => d.Reaction).WithMany()
                .HasForeignKey(d => d.ReactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Reaction_Reaction");
        });

        modelBuilder.Entity<PostTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post/Tag");

            entity.Property(e => e.PostId).HasColumnName("Post_Id");
            entity.Property(e => e.TagId).HasColumnName("Tag_Id");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Tag_Post");

            entity.HasOne(d => d.Tag).WithMany()
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post/Tag_Tag");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.ToTable("Preference");

            entity.Property(e => e.Theme).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Preferences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Preference_User");
        });

        modelBuilder.Entity<Reaction>(entity =>
        {
            entity.ToTable("Reaction");

            entity.Property(e => e.Message).HasMaxLength(50);
            entity.Property(e => e.PostDate)
                .HasColumnType("datetime")
                .HasColumnName("Post_Date");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reaction_User");
        });

        modelBuilder.Entity<ReactionLike>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Reaction/Like");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ReactionId).HasColumnName("Reaction_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Reaction).WithMany()
                .HasForeignKey(d => d.ReactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reaction/Like_Reaction");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reaction/Like_User");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("Report");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ObjectId).HasColumnName("Object_Id");
            entity.Property(e => e.ObjectType).HasColumnName("Object_Type");
            entity.Property(e => e.ReporterId).HasColumnName("Reporter_Id");
            entity.Property(e => e.ResolverId).HasColumnName("Resolver_Id");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Reporter).WithMany(p => p.ReportReporters)
                .HasForeignKey(d => d.ReporterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_User");

            entity.HasOne(d => d.Resolver).WithMany(p => p.ReportResolvers)
                .HasForeignKey(d => d.ResolverId)
                .HasConstraintName("FK_Report_User1");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.ToTable("Transport");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.ToTable("Trip");

            entity.Property(e => e.CreatorId).HasColumnName("Creator_Id");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PostedOn)
                .HasColumnType("datetime")
                .HasColumnName("Posted_On");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.Creator).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_User");
        });

        modelBuilder.Entity<TripBudget>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trip/Budget");

            entity.Property(e => e.BudgetId).HasColumnName("Budget_Id");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Budget).WithMany()
                .HasForeignKey(d => d.BudgetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Budget_Budget");

            entity.HasOne(d => d.Trip).WithMany()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Budget_Trip");
        });

        modelBuilder.Entity<TripCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trip/Country");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Country_Country");

            entity.HasOne(d => d.Trip).WithMany()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Country_Trip");
        });

        modelBuilder.Entity<TripDuration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trip/Duration");

            entity.Property(e => e.DurationId).HasColumnName("Duration_Id");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Duration).WithMany()
                .HasForeignKey(d => d.DurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Duration_Duration");

            entity.HasOne(d => d.Trip).WithMany()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Duration_Trip");
        });

        modelBuilder.Entity<TripTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trip/Tag");

            entity.Property(e => e.TagId).HasColumnName("Tag_Id");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Tag).WithMany()
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Tag_Tag");

            entity.HasOne(d => d.Trip).WithMany()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Tag_Trip");
        });

        modelBuilder.Entity<TripTransport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trip/Transport");

            entity.Property(e => e.TransportId).HasColumnName("Transport_Id");
            entity.Property(e => e.TripId).HasColumnName("Trip_Id");

            entity.HasOne(d => d.Transport).WithMany()
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Transport_Transport");

            entity.HasOne(d => d.Trip).WithMany()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip/Transport_Trip");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasColumnType("text");
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        base.OnModelCreating(modelBuilder);
    }
}
