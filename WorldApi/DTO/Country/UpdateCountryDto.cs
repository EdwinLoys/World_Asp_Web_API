using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.Country
{
    public class UpdateCountryDto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

    }
}
