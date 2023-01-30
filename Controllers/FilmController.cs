using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using WebApi.DBOperations;
using WebApi.Application.FilmOperations.Queries.GetFilm;
using static WebApi.Application.FilmOperations.Queries.GetFilmDetail.GetFilmDetailQuery;
using WebApi.Application.FilmOperations.Queries.GetFilmDetail;
using static WebApi.Application.FilmOperations.Commands.CreateFilm.CreateFilmCommand;
using WebApi.Application.FilmOperations.Commands.CreateFilm;
using static WebApi.Application.FilmOperations.Commands.UpdateFilm.UpdateFilmCommand;
using WebApi.Application.FilmOperations.Commands.UpdateFilm;
using WebApi.Application.FilmOperations.Commands.DeleteFilm;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]  
  [Route("[Controller]s")]
  public class FilmController : ControllerBase  
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public FilmController(IMovieStoreDbContext context , IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetFilms()
    {
      GetFilmQuery query = new GetFilmQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmDetail(int id)
    { 
      FilmDetailViewModel result; 
      
      GetFilmDetailQuery query = new GetFilmDetailQuery(_context, _mapper);
      query.FilmId = id;
      GetFilmDetailQueryValidator validator = new GetFilmDetailQueryValidator();
      validator.ValidateAndThrow(query);
      result = query.Handle();
      
      return Ok(result);
    }

    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateFilmModel newFilm)
    {
      CreateFilmCommand command = new CreateFilmCommand(_mapper,_context);
      command.Model = newFilm;
      CreateFilmCommandValidator validator = new CreateFilmCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle(); 
      return Ok();      
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id,[FromBody] UpdateFilmModel updatedFilm)
    {      
      UpdateFilmCommand command = new UpdateFilmCommand(_context);
      command.FilmId = id; 
      command.Model = updatedFilm; 

      UpdateFilmCommandValidator validator = new UpdateFilmCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {      
      DeleteFilmCommand command = new DeleteFilmCommand(_context);
      command.filmId = id;
      DeleteFilmCommandValidator validator = new DeleteFilmCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();      
      return Ok();
    }
  }
}