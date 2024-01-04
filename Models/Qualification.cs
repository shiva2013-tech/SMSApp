using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.Models
{
    public class Qualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationId { get; set; }

        public int StudentId { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal Percentage { get; set; }

        [ForeignKey("StudentId")] // Specify the foreign key relationship
        public Student? Student { get; set; }

    }
}
