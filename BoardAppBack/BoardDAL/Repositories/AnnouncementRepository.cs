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
            return await _context.Announcements
                    .FromSqlRaw("EXEC GetAnnouncements")
                    .ToListAsync();
        }

        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddAnnouncement @Title={0}, @Description={1}, @Category={2}, @SubCategory={3}",
                announcement.Title,
                announcement.Description,
                announcement.Category,
                announcement.SubCategory
            );
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC UpdateAnnouncement @Id={0}, @Title={1}, @Description={2}, @Status={3}, @Category={4}, @SubCategory={5}",
                announcement.Id,
                announcement.Title,
                announcement.Description,
                announcement.Status,
                announcement.Category,
                announcement.SubCategory
            );
        }

        public async Task DeleteAnnouncementAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC DeleteAnnouncement @Id={0}", id);
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(int id)
        {
            var announcements = await _context.Announcements
                .FromSqlRaw("EXEC GetAnnouncementsById @Id={0}", id)
                .ToListAsync();

            return announcements.FirstOrDefault();
        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category)
        {
            return await _context.Announcements
                .FromSqlRaw("EXEC GetAnnouncementsByCategoryOrSubCategory @CategoryOrSubCategory={0}", category)
                .ToListAsync();
        }
    }
}
