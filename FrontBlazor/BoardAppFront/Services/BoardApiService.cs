using BoardAppFront.Entities;
using BoardAppFront.Interfaces;
using System.Text.Json;
namespace BoardAppFront.Services
{
    public class BoardApiService : IBoardApiService
    {
        private readonly HttpClient _httpClient;

        public BoardApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetAnnoucementResponse>> GetDataAsync()
        {
            var result = new List<GetAnnoucementResponse>();
            var response = await _httpClient.GetAsync("/Announcement");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<List<GetAnnoucementResponse>>();
            }

            return result;
        }
        public async Task<List<GetAnnoucementResponse>> GetAnnouncementsByCategoryOrSubCategoryAsync(string category)
        {
            var result = new List<GetAnnoucementResponse>();

            var queryParams = new List<string>();
            if (!string.IsNullOrEmpty(category))
            {
                queryParams.Add($"category={Uri.EscapeDataString(category)}");
            }

            var url = "/Announcement/byCategory";
            if (queryParams.Count > 0)
            {
                url += "?" + string.Join("&", queryParams);
            }

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<List<GetAnnoucementResponse>>();
            }

            return result;
        }
        public async Task<GetAnnoucementResponse> GetAnnouncementByIdAsync(int id)
        {
            var result = new GetAnnoucementResponse();
            var response = await _httpClient.GetAsync($"/Announcement/{id}");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<GetAnnoucementResponse>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"No found: {error}");
            }
            return result;
        }
        public async Task<bool> CreateAnnouncementAsync(AddAnnouncementRequest addAnnouncementRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/Announcement", addAnnouncementRequest);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to create announcement: {error}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating announcement: {ex.Message}");
            }
        }
        public async Task<bool> DeleteAnnouncementAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/Announcement/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true; 
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to delete announcement: {error}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting announcement: {ex.Message}");
            }
        }
        public async Task<bool> UpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("/Announcement", updateAnnouncementRequest);

                if (response.IsSuccessStatusCode)
                {
                    return true; 
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to update announcement: {error}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating announcement: {ex.Message}");
            }
        }

    }
}
