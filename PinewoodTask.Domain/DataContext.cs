using Microsoft.EntityFrameworkCore;
using PinewoodTask.Domain.Models;

namespace PinewoodTask.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
