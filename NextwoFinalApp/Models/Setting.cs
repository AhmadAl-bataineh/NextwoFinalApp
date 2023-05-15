using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Setting : CommonProp
    {
        public int SettingId { get; set; }
        [Required(ErrorMessage ="Enter Mobile Phone")]
        public string? Phone { get; set; }
        public string? Phone2 { get; set; }
        public string? Mobile { get; set;}
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? FB { get; set; }
        public string? LinkedIn { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string? AboutUs { get; set; }
        public string? Fax { get; set; }
        public string? Img { get; set; }
       
    }
}
