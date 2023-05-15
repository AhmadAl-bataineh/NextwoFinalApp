using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Category : CommonProp
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Category Name")]
        public string? CategoryName { get; set; }
    }
}
