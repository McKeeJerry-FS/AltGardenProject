using AltGardenProject.Data;
using AltGardenProject.Models;
using AltGardenProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AltGardenProject.Services
{
    public class PlantService : IPlantService
    {
        private readonly ApplicationDbContext _context;
        public PlantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Plant> CreatePlantAsync(Plant plant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlantAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            var plants = await _context.Plants.Include(p => p.Garden).ToListAsync();
            return plants;
        }

        public Task<Plant?> GetPlantByIdAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        public Task<Plant?> UpdatePlantAsync(int plantId, Plant updatedPlant)
        {
            throw new NotImplementedException();
        }
    }
}
