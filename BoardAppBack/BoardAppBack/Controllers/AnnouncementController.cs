using BoardBLL.Interfaces;
using BoardDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using BoardBLL.DTOs.Request;
using BoardPLL.Constants;

namespace BoardPLL.Controllers
{
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnnouncementAsync()
        {
            try
            {
                return Ok(await _announcementService.GetAnnouncementAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncementAsync([FromBody] AnnouncementRequest announcementRequest)
        {
            try
            {
                await _announcementService.CreateAnnouncementAsync(announcementRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementAsync(int id)
        {
            try
            {
                await _announcementService.DeleteAnnouncementAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncementAsync([FromBody] UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            try
            {
                await _announcementService.UpdateAnnouncementAsync(updateAnnouncementRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet(RouteNames.ByCategory)]
        public async Task<ActionResult<List<Announcement>>> GetAnnouncementsByCategoryOrSubCategory([FromQuery] string category = null)
        {
            try
            {
                var announcements = await _announcementService.GetAnnouncementsByCategoryOrSubCategoryAsync(category);

                if (announcements == null || announcements.Count == 0)
                {
                    return NotFound("Оголошення не знайдено.");
                }

                return Ok(announcements);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> GetAnnouncementsById(int id)
        {
            try
            {
                return Ok(await _announcementService.GetAnnouncementById(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
