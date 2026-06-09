using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Web.Models
{
    public class PremiumRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AgeNextBirthday { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public decimal DeathSumInsured { get; set; }
    }
}