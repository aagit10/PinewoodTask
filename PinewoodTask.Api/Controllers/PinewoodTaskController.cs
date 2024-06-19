using Microsoft.AspNetCore.Mvc;
using PinewoodTask.Domain;
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
    }
}
