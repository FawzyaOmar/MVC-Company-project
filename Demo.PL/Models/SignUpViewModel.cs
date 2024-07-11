using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invaild format for email")]
        public string Email{ get; set; }
        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
        [Required]
        [MaxLength(6)]
        [Compare(nameof(Password),ErrorMessage ="passward mismatch")]
        public string ConfirmPassward { get; set; }
        [Required]
        public bool IsAgree { get; set; }



    }
}
