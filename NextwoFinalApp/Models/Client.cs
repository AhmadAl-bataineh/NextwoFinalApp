using NextwoFinalApp.Models.SharedProp;

namespace NextwoFinalApp.Models
{
    public class Client : CommonProp
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientPosition { get; set;}
        public string? Image { get; set;}


    }
}
