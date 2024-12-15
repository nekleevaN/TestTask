using BoardAppFront.Interfaces;
using BoardAppFront.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BoardAppFront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBoardApiService _boardApiService;

        public IndexModel(ILogger<IndexModel> logger, IBoardApiService boardApiService)
        {
            _logger = logger;
            _boardApiService = boardApiService;
        }

        public GetAnnoucementResponse Announcement {get; set;}
        public List<GetAnnoucementResponse> Announcements { get; set; }

        [BindProperty]
        public string SelectedCategoryOrSubCategory { get; set; }

        [BindProperty]
        public string SelectedCategory { get; set; }

        public Dictionary<string, List<string>> Categories { get; } = new()
        {
            { "Побутова техніка", new List<string> { "Холодильники", "Пральні машини", "Бойлери", "Печі", "Витяжки", "Мікрохвильові печі" } },
            { "Комп'ютерна техніка", new List<string> { "ПК", "Ноутбуки", "Монітори", "Принтери", "Сканери" } },
            { "Смартфони", new List<string> { "Android смартфони", "iOS/Apple смартфони" } },
            { "Інше", new List<string> { "Одяг", "Взуття", "Аксесуари", "Спортивне обладнання", "Іграшки" } }
        };
        [BindProperty]
        public AddAnnouncementRequest addAnnouncementRequest { get; set; }

        [BindProperty]
        public UpdateAnnouncementRequest UpdateAnnouncementRequest { get; set; }
        public async Task OnGetAsync()
        {
            await LoadAnnouncements();
        }
        public async Task OnGetByIdAsync(int id)
        {
            Announcement = await _boardApiService.GetAnnouncementByIdAsync(id);
            UpdateAnnouncementRequest = new UpdateAnnouncementRequest
            {
                Id = Announcement.Id,
                Title = Announcement.Title,
                Description = Announcement.Description,
                Status = Announcement.Status,
                Category = Announcement.Category,
                SubCategory = Announcement.SubCategory
            };
        }
        public async Task<IActionResult> OnPutUpdateAnnouncementAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            if (Categories.ContainsKey(SelectedCategory))
            {
                updateAnnouncementRequest.Category = SelectedCategory;
            }
            else
            {
                var key = Categories.FirstOrDefault(kvp => kvp.Value.Contains(SelectedCategory)).Key;
                updateAnnouncementRequest.Category = key;
                updateAnnouncementRequest.SubCategory = SelectedCategory;
            }
            var success = await _boardApiService.UpdateAnnouncementAsync(updateAnnouncementRequest);

            if (success)
            {
                return RedirectToPage();  
            }

            return Page(); 
        }
        public async Task LoadAnnouncements()
        {
            Announcements = await _boardApiService.GetDataAsync();
        }

        public async Task OnPostFilterAsync()
        {
            Announcements = await _boardApiService.GetAnnouncementsByCategoryOrSubCategoryAsync(SelectedCategoryOrSubCategory);
        }

        public async Task<IActionResult> OnPostCreateAnnouncementAsync(AddAnnouncementRequest addAnnouncementRequest)
        {
            if (Categories.ContainsKey(SelectedCategory))
            {
                addAnnouncementRequest.Category = SelectedCategory;
            }
            else 
            {
                var key = Categories.FirstOrDefault(kvp => kvp.Value.Contains(SelectedCategory)).Key;
                addAnnouncementRequest.Category = key;
                addAnnouncementRequest.SubCategory = SelectedCategory;
            }
            var success = await _boardApiService.CreateAnnouncementAsync(addAnnouncementRequest);

            if (success)
            {
                return RedirectToPage();  
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAnnouncementAsync(int id)
        {
            var success = await _boardApiService.DeleteAnnouncementAsync(id);

            if (success)
            {
                return RedirectToPage(); 
            }

            return Page();
        }
    }
}
