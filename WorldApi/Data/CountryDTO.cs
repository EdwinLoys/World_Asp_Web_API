using System.ComponentModel.DataAnnotations;

namespace WorldApi.Data
{
    public class CountryDTO
    {  
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
