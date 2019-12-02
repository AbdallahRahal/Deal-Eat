using System.ComponentModel.DataAnnotations;

namespace DealEat.WebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display( Name = "Email" )]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [Display(Name = "Prenom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone")]
        public int Telephone { get; set; }

        [Required]
        [StringLength( 100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6 )]
        [DataType( DataType.Password )]
        [Display( Name = "Password" )]
        public string Password { get; set; }

        [DataType( DataType.Password )]
        [Display( Name = "Confirm password" )]
        [Compare( "Password", ErrorMessage = "The password and confirmation password do not match." )]
        public string ConfirmPassword { get; set; }
    }
}
