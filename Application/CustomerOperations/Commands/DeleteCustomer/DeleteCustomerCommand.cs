using System;
using FluentValidation;
using System.Linq;
using WebApi.DBOperations;


namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int customerId {get; set;}
        private readonly IMovieStoreDbContext _context;
        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x=>x.Id == customerId);
            if(customer is null)
               throw new InvalidOperationException("Silinecek müşteri bulunamadi.");
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}