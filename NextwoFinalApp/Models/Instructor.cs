using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NextwoFinalApp.Models
{
    public class Instructor : CommonProp
    {
        public int InstructorId { get; set; }
        [Required]
        [Display(Name = "Instructor Name")]
        public string? InstructorName { get; set; }
        [Required]
        [Display(Name = "Instructor Picture")]
        public string? InstructorImg { get; set; }
        [Required]
        public string? Position { get; set; }
        public string? FB { get; set; }
        public string? Tw { get; set; }
        public string? LinkedIn { get; set; }

    }
}
