using BoardDAL.Data;
using BoardDAL.Entities;

namespace BoardDAL.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAnnouncementsAsync();
        Task CreateAnnouncementAsync(Announcement announcement);
        Task UpdateAnnouncementAsync(Announcement announcement);
        Task DeleteAnnouncementAsync(int id);
        Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category);
        Task<Announcement> GetAnnouncementByIdAsync(int id);
    }
}
