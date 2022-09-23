using System.ComponentModel.DataAnnotations;

namespace Books_Spot.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]
        [Required]
        public string BookTitle { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Publisher { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Publishing Date")]
        [Required]
        public DateTime PublishingDate { get; set; }
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        [StringLength(16, MinimumLength = 4)]
        [Display(Name = "ISBN Code")]
        public string ISBNCode { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Book Status")]
        public string BookStatus { get; set; } = string.Empty;
        [Display(Name = "Reserved by")]
        public string ReservedBy { get; set; } = string.Empty;
    }
}
