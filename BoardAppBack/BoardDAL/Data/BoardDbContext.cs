using BoardDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardDAL.Data
{
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> options)
            : base(options)
        {
        }
        public DbSet<Announcement> Announcements { get; set; }
    }
}
