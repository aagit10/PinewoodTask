using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PinewoodTask.Domain;
using PinewoodTask.Domain.Models;

namespace PinewoodTask.Services
{
    public class PinewoodTaskService
    {
        private readonly ILogger<PinewoodTaskService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public PinewoodTaskService(ILogger<PinewoodTaskService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            try
            {
                _logger.LogTrace("Fetching data context...");
                var dataContext = _serviceProvider.GetService<DataContext>();

                _logger.LogTrace("Adding customer...");
                await dataContext.AddAsync(customer);
                _logger.LogTrace("Saving changes...");
                await dataContext.SaveChangesAsync();

                return customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                _logger.LogTrace("Fetching data context...");
                var dataContext = _serviceProvider.GetService<DataContext>();

                _logger.LogTrace("Deleting customer...");
                dataContext.Remove(dataContext.Customers.Single(x => x.Id == id));
                _logger.LogTrace("Saving changes...");
                await dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _logger.LogTrace("Fetching data context...");
                var dataContext = _serviceProvider.GetService<DataContext>();

                _logger.LogTrace("Updating customer...");
                dataContext.Update(customer);
                _logger.LogTrace("Saving changes...");
                await dataContext.SaveChangesAsync();

                return customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            try
            {
                _logger.LogTrace("Fetching data context...");
                var dataContext = _serviceProvider.GetService<DataContext>();

                _logger.LogTrace("Fetching customer...");
                var customer = await dataContext.FindAsync<Customer>(id);
                _logger.LogTrace("Saving changes...");
                await dataContext.SaveChangesAsync();

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                _logger.LogTrace("Fetching data context...");
                var dataContext = _serviceProvider.GetService<DataContext>();

                _logger.LogTrace("Fetching customers...");
                var customers = (from c in dataContext.Customers select c).ToList();
                _logger.LogTrace("Saving changes...");
                await dataContext.SaveChangesAsync();

                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
