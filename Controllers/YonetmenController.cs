using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.YonetmenOperations.Commands.CreateYonetmen;
using WebApi.Application.YonetmenOperations.Commands.DeleteYonetmen;
using WebApi.Application.YonetmenOperations.Queries.GetYonetmenDetail;
using WebApi.Application.YonetmenOperations.Queries.GetYonetmen;
using WebApi.Application.YonetmenOperations.Commands.UpdateYonetmen;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class YonetmenController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public YonetmenController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult GetYonetmenlar()
        {
            GetYonetmenQuery query = new GetYonetmenQuery(_context, _mapper);
            var obj=query.Handle();
            return Ok(obj);
        }


        [HttpGet("{id}")]
        public ActionResult GetYonetmenDetail(int id)
        {
            GetYonetmenDetailQuery query = new GetYonetmenDetailQuery(_context,_mapper);
            query.YonetmenId=id;
            GetYonetmenDetailQueryValidator validations=new GetYonetmenDetailQueryValidator();
            validations.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }


        [HttpPost]
        public IActionResult AddYonetmen([FromBody] CreateYonetmenModel newGenre)
        {
            CreateYonetmenCommand command= new CreateYonetmenCommand(_mapper,_context);
            command.Model = newGenre;

            CreateYonetmenCommandValidator validations=new CreateYonetmenCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")] // Silme
        public IActionResult DeleteYonetmen(int id)
        {
            DeleteYonetmenCommand command = new DeleteYonetmenCommand(_context);
            command.YonetmenId = id;
            DeleteYonetmenCommandValidator cv = new DeleteYonetmenCommandValidator(); //validator sınıfını calıştırma
            cv.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

         [HttpPut("{id}")] //güncelleme
        public IActionResult UpdateYonetmen(int id,[FromBody] UpdateYonetmenModel updatedYonetmen)
        {
            UpdateYonetmenCommand command = new UpdateYonetmenCommand(_context);
            command.YonetmenId = id;
            command.Model = updatedYonetmen;

            UpdateYonetmenCommandValidator cv = new UpdateYonetmenCommandValidator();
            cv.ValidateAndThrow(command);
            command.Handle();


            return Ok();

        }
    }
}