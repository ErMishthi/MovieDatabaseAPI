using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController :ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // GET: api/actors/5/movies
        [HttpGet("actors/{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByActor(int id)
        {
            var movies = await _context.Actors
                .Where(ma => ma.Id == id)
                .Select(ma => ma.MovieActors)
                .ToListAsync();

            if (movies == null || movies.Count == 0)
            {
                return Ok(new List<Movie>());
            }

            return Ok( movies);
        }

        // GET: api/genres/Action/movies
        [HttpGet("genres/{genre}/movies")]
        public async Task<IActionResult> GetMoviesByGenre(string genre)
        {
            var movies = await _context.Movies
                .Where(m => m.MovieGenres.Any(g => g.Genre.Name == genre))
                .ToListAsync();

            return Ok(movies);
        }
    }
}

