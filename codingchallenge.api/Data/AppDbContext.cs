using codingchallenge.api.Models;
using Microsoft.EntityFrameworkCore;

namespace codingchallenge.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Notification> Notifications { get; set; }
    }
}