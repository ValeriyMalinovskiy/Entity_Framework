using Microsoft.EntityFrameworkCore;

namespace _2020._02._15_Fluent_API_3.Models
{
    class MovieDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieCast> MovieCasts { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<MovieDirection> MovieDirections { get; set; }

        public DbSet<Reviewer> Reviewers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder
                .UseSqlServer(@"Database=MovieDatabase;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany<MovieCast>(actor => actor.MovieCasts)
                .WithOne(movieCast => movieCast.Actor);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieCast>(movie => movie.MovieCasts)
                .WithOne(movieCast => movieCast.Movie);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieDirection>(movie => movie.MovieDirections)
                .WithOne(movieDirection => movieDirection.Movie);

            modelBuilder.Entity<Director>()
                .HasMany<MovieDirection>(director => director.MovieDirections)
                .WithOne(movieDirection => movieDirection.Director);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieGenre>(movie => movie.MovieGenres)
                .WithOne(movieGenre => movieGenre.Movie);

            modelBuilder.Entity<Movie>()
                .HasMany<Rating>(movie => movie.Ratings)
                .WithOne(rating => rating.Movie);

            modelBuilder.Entity<Reviewer>()
                .HasMany<Rating>(reviewer => reviewer.Ratings)
                .WithOne(rating => rating.Reviewer);

            modelBuilder.Entity<Genre>()
                .HasMany<MovieGenre>(genre => genre.MovieGenres)
                .WithOne(movieGenre => movieGenre.Genre);

            modelBuilder.Entity<MovieCast>()
                .HasKey(movieCast => new { movieCast.ActorId, movieCast.MovieId });

            modelBuilder.Entity<MovieDirection>()
                .HasKey(movieDirection => new { movieDirection.DirectorId, movieDirection.MovieId });

            modelBuilder.Entity<Rating>()
                .HasKey(rating => new { rating.ReviewerId, rating.MovieId });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(movieGenre => new { movieGenre.MovieId, movieGenre.GenreId });
        }
    }
}
