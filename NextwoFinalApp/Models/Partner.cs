using NextwoFinalApp.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models
{
    public class Partner : CommonProp
    {
        public int PartnerId { get; set; }
        [Required]
        public string? PartnerName { get; set; }
        [Required]
        public string? PartnerImg { get; set; }
    }
}
