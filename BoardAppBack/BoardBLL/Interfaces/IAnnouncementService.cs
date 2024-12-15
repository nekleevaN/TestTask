using BoardBLL.DTOs;
using BoardBLL.DTOs.Request;
using BoardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBLL.Interfaces
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementDTO>> GetAnnouncementAsync();
        Task CreateAnnouncementAsync(AnnouncementRequest announcementRequest);
        Task DeleteAnnouncementAsync(int id);
        Task UpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest);
        Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category);
        Task<Announcement> GetAnnouncementById(int id);
    }
}
