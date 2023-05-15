using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Blog : CommonProp
    {
        public int BlogId { get; set; }
        [Required]
        public string? BlogTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]

        public string? BlogDescription { get; set; }
        [Required]
        public string? BlogImg { get; set; }

    }
}
