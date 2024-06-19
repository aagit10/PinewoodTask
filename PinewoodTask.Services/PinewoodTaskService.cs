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
                _logger.LogTrace("Saving...");
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
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
