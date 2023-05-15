using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextwoFinalApp.Models
{
    public class Course : CommonProp
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
        public string? Img { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
        public string? Duration { get; set; }
        [Required]
        public int? Hours { get; set; }
        public int? Rate { get; set; }
        public Venus venu { get; set; }

        public enum Venus { Online, Offline,Recorded }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
