using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.SiparisOperations.Commands.CreateSiparis;
using WebApi.Application.SiparisOperations.Queries.GetSiparisDetail;
using WebApi.Application.SiparisOperations.Queries.GetSiparis;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]  
  [Route("[Controller]s")]
  public class OrderController : ControllerBase  
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public OrderController(IMovieStoreDbContext context , IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
      GetSiparisQuery query = new GetSiparisQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderDetail(int id)
    { 
      SiparisDetailViewModel result; 
      
      GetSiparisDetailQuery query = new GetSiparisDetailQuery(_context, _mapper);
      query.SiparisId = id;
      GetSiparisDetailQueryValidator validator = new GetSiparisDetailQueryValidator();
      validator.ValidateAndThrow(query);
      result = query.Handle();
      
      return Ok(result);
    }

    [HttpPost]
    public IActionResult AddOrder([FromBody] CreateSiparisModel newOrder)
    {
      CreateSiparisCommand command = new CreateSiparisCommand(_mapper,_context);
      command.Model = newOrder;
      CreateSiparisCommandValidator validator = new CreateSiparisCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle(); 
      return Ok();      
    }

    
  }
}