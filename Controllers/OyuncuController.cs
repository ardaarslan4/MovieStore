using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OyuncuOperations.Commands.CreateOyuncu;
using WebApi.Application.OyuncuOperations.Commands.DeleteOyuncu;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncu;
using WebApi.Application.OyuncuOperations.Commands.UpdateOyuncu;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class OyuncuController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OyuncuController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult GetOyuncular()
        {
            GetOyuncuQuery query = new GetOyuncuQuery(_context, _mapper);
            var obj=query.Handle();
            return Ok(obj);
        }


        [HttpGet("{id}")]
        public ActionResult GetOyuncuDetail(int id)
        {
            GetOyuncuDetailQuery query = new GetOyuncuDetailQuery(_context,_mapper);
            query.OyuncuId=id;
            GetOyuncuDetailQueryValidator validations=new GetOyuncuDetailQueryValidator();
            validations.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }


        [HttpPost]
        public IActionResult AddOyuncu([FromBody] CreateOyuncuModel newGenre)
        {
            CreateOyuncuCommand command= new CreateOyuncuCommand(_mapper,_context);
            command.Model = newGenre;

            CreateOyuncuCommandValidator validations=new CreateOyuncuCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")] // Silme
        public IActionResult DeleteOyuncu(int id)
        {
            DeleteOyuncuCommand command = new DeleteOyuncuCommand(_context);
            command.oyuncuId = id;
            DeleteOyuncuCommandValidator cv = new DeleteOyuncuCommandValidator(); //validator sınıfını calıştırma
            cv.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")] //güncelleme
        public IActionResult UpdateOyuncu(int id,[FromBody] UpdateOyuncuModel updatedOyuncu)
        {
            UpdateOyuncuCommand command = new UpdateOyuncuCommand(_context);
            command.OyuncuId = id;
            command.Model = updatedOyuncu;

            UpdateOyuncuCommandValidator cv = new UpdateOyuncuCommandValidator();
            cv.ValidateAndThrow(command);
            command.Handle();


            return Ok();

        }
    }
}