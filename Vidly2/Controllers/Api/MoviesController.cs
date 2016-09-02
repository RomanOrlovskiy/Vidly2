﻿using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDto = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDto);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie (MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movieInDb);
            _context.SaveChanges();

            //This customer object has an ID that is generated by the DB
            //so we want to add this ID in our DTO and return it to the client.
            movieDto.Id = movieInDb.Id;

            //Here, as a part of RESTful convention, we need to return the URI 
            //of the newly created resource to the client,like "api/movie/10"
            //This also returns 201 Created isntead of 200 OK.
            return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
