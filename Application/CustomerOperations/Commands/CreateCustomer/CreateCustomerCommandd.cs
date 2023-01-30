using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var customer =_dbContext.Customers.SingleOrDefault(x=>x.Email == Model.Email);
            
            if(customer is not null)
                throw new InvalidOperationException("Customer Zaten Mevcut.");

            customer=_mapper.Map<Customer>(Model);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public string? CustomerAdi{get;set;}
        public string? CustomerSoyadi{get;set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Genre>? FavoriFilmTurleri{get;set;}
        public List<Film>? SatinAlinanFilmler{get;set;}
        
    }
}