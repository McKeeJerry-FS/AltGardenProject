using AltGardenProject.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltGardenProject.Models
{
    public class Garden
    {
        [Key]
        public int GardenId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        public Location? Location { get; set; }
        public GardenType? Type { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public DateTime? LastWatered { get; set;} = DateTime.Now;
        public DateTime? LastFertilized { get; set; } = DateTime.Now;
        public int Humidity { get; set; }
        public decimal Temperature { get; set; }
        public decimal PH { get; set; }
        public decimal VPD { get; set; }
        public int LightingStrength { get; set; }

        public virtual ICollection<Plant>? Plants { get; set; }

    }
}
