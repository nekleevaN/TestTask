using Xunit;
using Moq;
using BoardBLL.Services;
using BoardBLL.Interfaces;
using BoardDAL.Interfaces;
using BoardBLL.DTOs;
using BoardBLL.DTOs.Request;
using BoardDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AnnouncementServiceTests
{
    private readonly Mock<IAnnouncementRepository> _mockRepository;
    private readonly IAnnouncementService _announcementService;

    public AnnouncementServiceTests()
    {
        _mockRepository = new Mock<IAnnouncementRepository>();
        _announcementService = new AnnouncementService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAnnouncementAsync_ReturnsListOfAnnouncements()
    {
        // Arrange
        var announcements = new List<Announcement> { new Announcement { Id = 1, Title = "Test" } };
        _mockRepository.Setup(repo => repo.GetAnnouncementsAsync()).ReturnsAsync(announcements);

        // Act
        var result = await _announcementService.GetAnnouncementAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal("Test", result[0].Title);
    }

    [Fact]
    public async Task CreateAnnouncementAsync_CreatesAnnouncement()
    {
        // Arrange
        var request = new AnnouncementRequest { Title = "Title", Description = "Description", Category = "Category", SubCategory = "SubCategory" };

        // Act
        await _announcementService.CreateAnnouncementAsync(request);

        // Assert
        _mockRepository.Verify(repo => repo.CreateAnnouncementAsync(It.IsAny<Announcement>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAnnouncementAsync_DeletesAnnouncement()
    {
        // Arrange
        var id = 1;

        // Act
        await _announcementService.DeleteAnnouncementAsync(id);

        // Assert
        _mockRepository.Verify(repo => repo.DeleteAnnouncementAsync(id), Times.Once);
    }

    [Fact]
    public async Task UpdateAnnouncementAsync_UpdatesAnnouncement()
    {
        // Arrange
        var updateRequest = new UpdateAnnouncementRequest { Id = 1, Title = "Updated Title" };

        // Act
        await _announcementService.UpdateAnnouncementAsync(updateRequest);

        // Assert
        _mockRepository.Verify(repo => repo.UpdateAnnouncementAsync(It.IsAny<Announcement>()), Times.Once);
    }

    [Fact]
    public async Task GetAnnouncementsByCategoryOrSubCategoryAsync_ReturnsListOfAnnouncementsByCategory()
    {
        // Arrange
        var category = "TestCategory";
        var announcements = new List<Announcement> { new Announcement { Category = "TestCategory" } };
        _mockRepository.Setup(repo => repo.GetAnnouncementsByCategoryOrSubCategoryAsync(category)).ReturnsAsync(announcements);

        // Act
        var result = await _announcementService.GetAnnouncementsByCategoryOrSubCategoryAsync(category);

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal("TestCategory", result[0].Category);
    }

    [Fact]
    public async Task GetAnnouncementById_ReturnsAnnouncement()
    {
        // Arrange
        var id = 1;
        var announcement = new Announcement { Id = id, Title = "Test" };
        _mockRepository.Setup(repo => repo.GetAnnouncementByIdAsync(id)).ReturnsAsync(announcement);

        // Act
        var result = await _announcementService.GetAnnouncementById(id);

        // Assert
        Assert.Equal(id, result.Id);
        Assert.Equal("Test", result.Title);
    }

    [Fact]
    public async Task GetAnnouncementAsync_ReturnsEmptyListWhenNoAnnouncements()
    {
        // Arrange
        var announcements = new List<Announcement>();
        _mockRepository.Setup(repo => repo.GetAnnouncementsAsync()).ReturnsAsync(announcements);

        // Act
        var result = await _announcementService.GetAnnouncementAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task CreateAnnouncementAsync_ThrowsExceptionWhenFailed()
    {
        // Arrange
        var request = new AnnouncementRequest { Title = "Title", Description = "Description" };
        _mockRepository.Setup(repo => repo.CreateAnnouncementAsync(It.IsAny<Announcement>())).ThrowsAsync(new System.Exception("Error"));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _announcementService.CreateAnnouncementAsync(request));
    }

    [Fact]
    public async Task DeleteAnnouncementAsync_ThrowsExceptionWhenNotFound()
    {
        // Arrange
        var id = 1;
        _mockRepository.Setup(repo => repo.DeleteAnnouncementAsync(id)).ThrowsAsync(new System.Exception("Not found"));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _announcementService.DeleteAnnouncementAsync(id));
    }

    [Fact]
    public async Task UpdateAnnouncementAsync_ThrowsExceptionWhenFailed()
    {
        // Arrange
        var updateRequest = new UpdateAnnouncementRequest { Id = 1, Title = "Updated Title" };
        _mockRepository.Setup(repo => repo.UpdateAnnouncementAsync(It.IsAny<Announcement>())).ThrowsAsync(new System.Exception("Error"));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _announcementService.UpdateAnnouncementAsync(updateRequest));
    }

    [Fact]
    public async Task GetAnnouncementsByCategoryOrSubCategoryAsync_ReturnsEmptyListWhenNotFound()
    {
        // Arrange
        var category = "NonExistentCategory";
        var announcements = new List<Announcement>();
        _mockRepository.Setup(repo => repo.GetAnnouncementsByCategoryOrSubCategoryAsync(category)).ReturnsAsync(announcements);

        // Act
        var result = await _announcementService.GetAnnouncementsByCategoryOrSubCategoryAsync(category);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAnnouncementById_ReturnsNotFoundWhenNoAnnouncement()
    {
        // Arrange
        var id = 999;
        _mockRepository.Setup(repo => repo.GetAnnouncementByIdAsync(id)).ReturnsAsync((Announcement)null);

        // Act
        var result = await _announcementService.GetAnnouncementById(id);

        // Assert
        Assert.Null(result);
    }
}
