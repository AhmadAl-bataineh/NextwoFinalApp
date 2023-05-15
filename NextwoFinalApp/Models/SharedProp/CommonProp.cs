using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models.SharedProp
{
    public class CommonProp
    {
        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; }
        [Display(Name = "Is Published")]

        public bool IsPublished { get; set; }
        [Display(Name = "Is Deleted")]

        public bool IsDeleted { get; set; }
        [Display(Name = "User")]

        public string? UserId { get; set; }

    }
}
