using AltGardenProject.Models;

namespace AltGardenProject.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant?> GetPlantByIdAsync(int plantId);
        Task<Plant> CreatePlantAsync(Plant plant);
        Task<Plant?> UpdatePlantAsync(int plantId, Plant updatedPlant);
        Task<bool> DeletePlantAsync(int plantId);

    }
}
