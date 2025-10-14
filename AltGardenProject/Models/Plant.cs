using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltGardenProject.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Species { get; set; }
        public DateTime DatePlanted { get; set; }
        [ForeignKey("GardenId")]
        public int GardenId { get; set; }
        public Garden? Garden { get; set; }
        public int Required_PH { get; set; }
        public int Required_Temperature { get; set; }
        public int Required_Humidity { get; set; }
        public int Required_LightingStrength { get; set; }
        public DateTime? Harvested { get; set; } = DateTime.Now;
    }
}
