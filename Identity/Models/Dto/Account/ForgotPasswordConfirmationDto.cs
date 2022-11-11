using System.ComponentModel.DataAnnotations;


namespace Identity.Models.Dto.Account
{
    public class ForgotPasswordConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
