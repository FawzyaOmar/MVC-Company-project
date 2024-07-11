using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
        [Required]
        [MaxLength(6),]
        [Compare(nameof(Password), ErrorMessage = "passward mismatch")]
        public string ConfirmPassward { get; set; }

        public string Email { get; set; }   
        public string Token { get; set; }



    }
}
