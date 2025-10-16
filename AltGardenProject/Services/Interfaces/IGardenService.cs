using AltGardenProject.Models;

namespace AltGardenProject.Services.Interfaces
{
    public interface IGardenService
    {
        Task<List<Garden>> GetAllGardensAsync();
        Task<Garden?> GetGardenByIdAsync(int gardenId);
        Task<Garden> CreatePlantAsync(Garden garden);
        Task<Garden?> UpdatePlantAsync(int gardenId, Garden updatedGarden);
        Task<bool> DeletePlantAsync(int gardenId);

    }
}
