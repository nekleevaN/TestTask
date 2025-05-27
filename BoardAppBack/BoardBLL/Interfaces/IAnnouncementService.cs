using BoardBLL.DTOs;
using BoardBLL.DTOs.Request;
using BoardDAL.Entities;

namespace BoardBLL.Interfaces
{
    public interface IAnnouncementService
    {
        /// <summary>
        /// Отримує список усіх оголошень.
        /// </summary>
        Task<List<AnnouncementDTO>> GetAnnouncementAsync();

        /// <summary>
        /// Створює нове оголошення на основі запиту.
        /// </summary>
        /// <param name="announcementRequest">Дані для створення оголошення.</param>
        Task CreateAnnouncementAsync(AnnouncementRequest announcementRequest);

        /// <summary>
        /// Видаляє оголошення за вказаним ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор оголошення.</param>
        Task DeleteAnnouncementAsync(int id);

        /// <summary>
        /// Оновлює існуюче оголошення.
        /// </summary>
        /// <param name="updateAnnouncementRequest">Дані для оновлення оголошення.</param>
        Task UpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest);

        /// <summary>
        /// Отримує список оголошень за категорією або підкатегорією.
        /// </summary>
        /// <param name="category">Назва категорії або підкатегорії.</param>
        Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category);

        /// <summary>
        /// Отримує оголошення за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор оголошення.</param>
        Task<Announcement> GetAnnouncementById(int id);
    }
}
