using BoardAppFront.Entities;

namespace BoardAppFront.Interfaces
{
    public interface IBoardApiService
    {
        Task<List<GetAnnoucementResponse>> GetDataAsync();
        Task<List<GetAnnoucementResponse>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category);
        Task<bool> CreateAnnouncementAsync(AddAnnouncementRequest addAnnouncementRequest);
        Task<bool> DeleteAnnouncementAsync(int id);
        Task<bool> UpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest);
        Task<GetAnnoucementResponse> GetAnnouncementByIdAsync(int id);
    }
}
