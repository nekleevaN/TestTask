using BoardDAL.Data;
using BoardDAL.Entities;
using BoardDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoardDAL.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        protected readonly BoardDbContext _context;

        public AnnouncementRepository(BoardDbContext context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnnouncementAsync(int id)
        {
            var entity = await _context.Announcements.FindAsync(id);
            if (entity != null)
            {
                _context.Announcements.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(int id)
        {
            return await _context.Announcements.FindAsync(id);
        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category)
        {
            return await _context.Announcements
                .Where(a => a.Category == category || a.SubCategory == category)
                .ToListAsync();
        }
    }
}
