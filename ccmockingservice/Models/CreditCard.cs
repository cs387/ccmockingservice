
using System.ComponentModel.DataAnnotations;
namespace ccmockingservice.Models
{
    public class CreditCard
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(15)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number must be numeric")]
        public string Number { get; set; }

    }
}