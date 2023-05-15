using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Slider : CommonProp
    {
        [Display(Name = "Slider Id")]
        public int SliderId { get; set; }
        [Display(Name = "Slider Title")]
        [Required(ErrorMessage ="Enter Title")]
        public string? SliderTitle { get; set; }
        [Display(Name = "Slider Title")]
        [Required(ErrorMessage = "Enter Sub Title")]
        public string? SliderSubTitle { get; set; }
        [Required(ErrorMessage = "Enter Location")]
        public string? Location { get; set; }
        [Display(Name = "Slider Discount")]
        [Required(ErrorMessage = "Enter Discount")]
        public int DiscountPer { get; set; }
        [Display(Name = "Price")]
        [Range(50,500,ErrorMessage = "Range 50 to 5000")]
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public string? Txtbtn { get; set; }
        public string? UrlBtn { get; set; }
        [Required(ErrorMessage = "Select Image")]

        public string? SliderImg { get; set; }





    }
}
