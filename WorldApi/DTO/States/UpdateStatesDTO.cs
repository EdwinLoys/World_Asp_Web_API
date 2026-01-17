using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.States
{
    public class UpdateStatesDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public double Population { get; set; }

        [Required]
        [MaxLength(10)]
        public int CountryId { get; set; }
    }
}
