using BoardAppFront.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BoardAppFront.Entities;

namespace BoardAppFront.Pages
{
    public class EditAnnouncementModel : PageModel
    {
        private readonly IBoardApiService _boardApiService;

        public EditAnnouncementModel(IBoardApiService boardApiService)
        {
            _boardApiService = boardApiService;
        }

        [BindProperty]
        public UpdateAnnouncementRequest UpdateAnnouncementRequest { get; set; }


        [BindProperty]
        public string SelectedCategory { get; set; }

        public Dictionary<string, List<string>> Categories { get; } = new()
        {
            { "Побутова техніка", new List<string> { "Холодильники", "Пральні машини", "Бойлери", "Печі", "Витяжки", "Мікрохвильові печі" } },
            { "Комп'ютерна техніка", new List<string> { "ПК", "Ноутбуки", "Монітори", "Принтери", "Сканери" } },              { "Смартфони", new List<string> { "Android смартфони", "iOS/Apple смартфони" } },
            { "Інше", new List<string> { "Одяг", "Взуття", "Аксесуари", "Спортивне обладнання", "Іграшки" } }
        };

        public async Task OnGetAsync(int announcementId)
        {
            if (announcementId != 0)
            {
                var announcement = await _boardApiService.GetAnnouncementByIdAsync(announcementId);
                UpdateAnnouncementRequest = new UpdateAnnouncementRequest
                {
                    Id = announcementId,
                    Title = announcement.Title,
                    Description = announcement.Description,
                    Status = announcement.Status,
                    Category = announcement.Category,
                    SubCategory = announcement.SubCategory
                };

                SelectedCategory = announcement?.SubCategory ?? UpdateAnnouncementRequest.Category;
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Categories.ContainsKey(SelectedCategory))
            {
                UpdateAnnouncementRequest.Category = SelectedCategory;
            }
            else
            {
                var key = Categories.FirstOrDefault(kvp => kvp.Value.Contains(SelectedCategory)).Key;
                UpdateAnnouncementRequest.Category = key;
                UpdateAnnouncementRequest.SubCategory = SelectedCategory;
            }
            await _boardApiService.UpdateAnnouncementAsync(UpdateAnnouncementRequest);

            return RedirectToPage("Index");
        }
    }
}
