using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardBLL.DTOs;
using BoardBLL.DTOs.Request;
using BoardDAL.Entities;

namespace BoardBLL.Mappers
{
    public static class AnnouncementMapper
    {
        public static AnnouncementDTO ToDTO(this Announcement announcement)
        {
            return new AnnouncementDTO
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Description = announcement.Description,
                CreatedDate = announcement.CreatedDate,
                Status = announcement.Status,
                Category = announcement.Category,
                SubCategory = announcement.SubCategory,
            };
        }

        public static Announcement ToEntity(this AnnouncementDTO announcementDTO)
        {
            return new Announcement
            {
                Title = announcementDTO.Title,
                Description = announcementDTO.Description,
                CreatedDate = announcementDTO.CreatedDate,
                Status = announcementDTO.Status,
                Category = announcementDTO.Category,
                SubCategory = announcementDTO.SubCategory,
            };
        }
        public static Announcement UpdateDtoToEntity(this AnnouncementRequest announcementRequest)
        {
            return new Announcement()
            {
                Title = announcementRequest.Title,
                Description = announcementRequest.Description,
                Category = announcementRequest.Category,
                SubCategory = announcementRequest.SubCategory
            };
        }

        public static Announcement DtoToEntity(this UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            return new Announcement()
            {
                Id = updateAnnouncementRequest.Id,
                Title = updateAnnouncementRequest.Title,
                Description = updateAnnouncementRequest.Description,
                Status = updateAnnouncementRequest.Status,
                Category = updateAnnouncementRequest.Category,
                SubCategory = updateAnnouncementRequest.SubCategory,
            };
        }
    }
}
