using AltGardenProject.Models;
using AltGardenProject.Services.Interfaces;

namespace AltGardenProject.Services
{
    public class GardenService : IGardenService
    {
        public Task<Garden> CreatePlantAsync(Garden garden)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlantAsync(int gardenId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Garden>> GetAllGardensAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Garden?> GetGardenByIdAsync(int gardenId)
        {
            throw new NotImplementedException();
        }

        public Task<Garden?> UpdatePlantAsync(int gardenId, Garden updatedGarden)
        {
            throw new NotImplementedException();
        }
    }
}
