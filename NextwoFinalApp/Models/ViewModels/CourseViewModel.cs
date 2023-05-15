using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextwoFinalApp.Models.ViewModels
{
    public class CourseViewModel : CommonProp
    {
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Course Title")]
        public string? CourseTitle { get; set; }
        [Required]
        [Display(Name = "Course Description")]
        [DataType(DataType.MultilineText)]
        public string? CourseDesc { get; set; }
        [Required]
        [Display(Name = "Course Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Course Image")]
        public IFormFile? Img { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; }
        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
        public string? Duration { get; }
        [Required]
        public int? Hours { get; set; }
        public int? Rate { get; }
        public Venus Venu { get; set; }

        public enum Venus { Online, Offline, Recorded }
        [ForeignKey("Category")]
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
