using System.ComponentModel.DataAnnotations;

namespace MovieDatabaseAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }

        // Relationships
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Relationships
        public ICollection<MovieActor> MovieActors { get; set; }
    }

    public class Director
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Relationships
        public ICollection<Movie> Movies { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Relationships
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public int Rating { get; set; }
        public string Author { get; set; }

        // Relationships
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }

    // Many-to-Many Join Tables
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }

    public class MovieGenre
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

