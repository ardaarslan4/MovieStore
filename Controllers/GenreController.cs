using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

using WebApi.Application.GenreOperations.UpdateGenre;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.CreateGenre;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId =id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Model =updateGenre;

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }


}
