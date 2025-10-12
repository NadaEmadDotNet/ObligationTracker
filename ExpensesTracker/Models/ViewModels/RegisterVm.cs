using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Models.ViewModels
{
    public class RegisterVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [EmailAddress(ErrorMessage = " plz enter Correct mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
