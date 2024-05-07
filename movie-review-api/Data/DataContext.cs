using Microsoft.EntityFrameworkCore;
using movie_review_api.ConfigSeed;
using movie_review_api.Data.Models;

namespace movie_review_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
             base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorSeed());
            modelBuilder.ApplyConfiguration(new DirectorSeed());
            modelBuilder.ApplyConfiguration(new GenreSeed());
            modelBuilder.ApplyConfiguration(new MovieActorSeed());
            modelBuilder.ApplyConfiguration(new MovieGenreSeed());
            modelBuilder.ApplyConfiguration(new MovieSeed());
            modelBuilder.ApplyConfiguration(new ReviewSeed());

            modelBuilder.Entity<MovieActor>()
            .HasKey(sc => new { sc.MovieId, sc.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(sc => sc.Movie)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(sc => sc.Actor)
                .WithMany(c => c.MovieActors)
                .HasForeignKey(sc => sc.ActorId);

            modelBuilder.Entity<MovieGenre>()
            .HasKey(sc => new { sc.MovieId, sc.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(sc => sc.Movie)
                .WithMany(s => s.MovieGenres)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(sc => sc.Genre)
                .WithMany(c => c.MovieGenres)
                .HasForeignKey(sc => sc.GenreId);

            modelBuilder.Entity<Movie>()
                .HasMany(f => f.Reviews)
                .WithOne(n => n.Movie)
                .HasForeignKey(n => n.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
