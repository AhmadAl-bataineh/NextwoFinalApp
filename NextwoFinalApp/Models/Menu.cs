using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Menu : CommonProp
    {
        [Display(Name = "Menu Id")]
        public int MenuId { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage ="Enter Title")]
        [MaxLength(13,ErrorMessage = "Max 13 Char ")]
        [MinLength(3, ErrorMessage = "Min 13 Char ")]

        public string? MenuTitle { get; set; }
        [Display(Name = "Titel ")]
        [Required(ErrorMessage = "Enter Title")]
        public string? MenuUrl { get; set; }
        [Display(Name = "Titel ")]
        public int? ParentId { get; set; }
    }
}
