using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
