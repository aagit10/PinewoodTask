using Microsoft.AspNetCore.Mvc;
using PinewoodTask.Domain.Models;
using PinewoodTask.Services;

namespace PinewoodTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinewoodTaskController : ControllerBase
    {
        private readonly ILogger<PinewoodTaskController> _logger;
        private readonly PinewoodTaskService _pinewoodTaskService;

        public PinewoodTaskController(ILogger<PinewoodTaskController> logger, PinewoodTaskService pinewoodTaskService)
        {
            _logger = logger;
            _pinewoodTaskService = pinewoodTaskService;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            try
            {
                _logger.LogTrace("Adding customer...");
                return await _pinewoodTaskService.AddCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                _logger.LogTrace("Deleting customer...");
                await _pinewoodTaskService.DeleteCustomerAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _logger.LogTrace("Updating customer...");
                return await _pinewoodTaskService.UpdateCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("GetCustomer/{id}")]
        public async Task<Customer> GetCustomerAsync(int id)
        {
            try
            {
                _logger.LogTrace("Fetching customer...");
                return await _pinewoodTaskService.GetCustomerAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                _logger.LogTrace("Fetching customers...");
                return await _pinewoodTaskService.GetCustomersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
