using JiPP_2.Data;
using JiPP_2.Models;

namespace JiPP_2.Repositories
{
    public class CustomerManager
    {
        private ApplicationDbContext _context;
        public CustomerManager(ApplicationDbContext context)
        { 
            _context = context;
        }
        public CustomerManager AddCustomer(CustomerModel customerModel)
        {
            _context.Customers.Add(customerModel);
            _context.SaveChanges();
            return this;
        }

        public CustomerManager RemoveCustomer(CustomerModel customerModel)
        {
            _context.Customers.Remove(customerModel);
            _context.SaveChanges();
            return this;
        }

        public CustomerManager UpdateCustomer(CustomerModel CustomerModel)
        {
            _context.Customers.Update(CustomerModel);
            _context.SaveChanges();
            return this;
        }

        public CustomerModel GetCustomer(int id)
        {
            return _context.Customers.SingleOrDefault(customer => customer.Id == id);
        }

        public List<CustomerModel> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
