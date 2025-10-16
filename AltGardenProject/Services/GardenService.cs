using AltGardenProject.Data;
using AltGardenProject.Models;
using AltGardenProject.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AltGardenProject.Services
{
    public class GardenService : IGardenService
    {
        private readonly ApplicationDbContext _context;

        public GardenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Garden> CreatePlantAsync(Garden garden)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlantAsync(int gardenId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Garden>> GetAllGardensAsync()
        {
            var gardens = await _context.Gardens.ToListAsync();
            return gardens;
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
