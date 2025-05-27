using BoardDAL.Data;
using BoardDAL.Entities;

namespace BoardDAL.Interfaces
{
    public interface IAnnouncementRepository
    {
        /// <summary>
        /// Отримує список усіх оголошень з бази даних.
        /// </summary>
        Task<List<Announcement>> GetAnnouncementsAsync();

        /// <summary>
        /// Додає нове оголошення до бази даних.
        /// </summary>
        /// <param name="announcement">Об'єкт оголошення для створення.</param>
        Task CreateAnnouncementAsync(Announcement announcement);

        /// <summary>
        /// Оновлює наявне оголошення в базі даних.
        /// </summary>
        /// <param name="announcement">Оголошення з оновленими даними.</param>
        Task UpdateAnnouncementAsync(Announcement announcement);

        /// <summary>
        /// Видаляє оголошення з бази даних за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор оголошення для видалення.</param>
        Task DeleteAnnouncementAsync(int id);

        /// <summary>
        /// Повертає список оголошень за категорією або підкатегорією.
        /// </summary>
        /// <param name="category">Назва категорії або підкатегорії.</param>
        Task<List<Announcement>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category);

        /// <summary>
        /// Повертає одне оголошення за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор оголошення.</param>
        Task<Announcement> GetAnnouncementByIdAsync(int id);
    }
}
