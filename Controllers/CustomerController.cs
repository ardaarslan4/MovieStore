using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.DBOperations;
using FluentValidation;
using WebApi.TokenOperations.Models;


namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        public readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper ,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration=configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_mapper,_context);
            command.Model= newCustomer;
            command.Handle();

            return Ok();
        }


        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model=login;
            var token = command.Handle();
            return token;
        }


        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken=token;
            var resultToken = command.Handle();
            return resultToken;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {      
          DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
          command.customerId = id;
          DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
          validator.ValidateAndThrow(command);
          command.Handle();      
          return Ok();
        }
    }
}