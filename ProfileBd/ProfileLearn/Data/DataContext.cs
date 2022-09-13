using Microsoft.EntityFrameworkCore;
using ProfileLearn.Entities;

namespace ProfileLearn.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<HistoryEntity> EntitesHisotry { get; set; }
    }
}
