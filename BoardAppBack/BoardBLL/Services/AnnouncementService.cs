using BoardBLL.Interfaces;
using BoardDAL.Entities;
using BoardBLL.DTOs;
using BoardBLL.DTOs.Request;
using BoardBLL.Mappers;
using BoardDAL.Interfaces;

namespace BoardBLL.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository AnnouncementRepository)
        {
            _announcementRepository = AnnouncementRepository;

        }

        public async Task<List<AnnouncementDTO>> GetAnnouncementAsync()
        {
            var announcements = await _announcementRepository.GetAnnouncementsAsync();
            return announcements.Select(i => AnnouncementMapper.ToDTO(i)).ToList();
        }
        public async Task CreateAnnouncementAsync(AnnouncementRequest announcementRequest)
        {
            await _announcementRepository.CreateAnnouncementAsync(announcementRequest.UpdateDtoToEntity());
        }
        public async Task DeleteAnnouncementAsync(int id)
        {
            await _announcementRepository.DeleteAnnouncementAsync(id);
        }
        public async Task UpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            await _announcementRepository.UpdateAnnouncementAsync(updateAnnouncementRequest.DtoToEntity());
        }
        public async Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category)
        {
            return await _announcementRepository.GetAnnouncementsByCategoryOrSubCategoryAsync(category);
        }
        public async Task<Announcement> GetAnnouncementById(int id)
        {
            return await _announcementRepository.GetAnnouncementByIdAsync(id);
        }
    }
}