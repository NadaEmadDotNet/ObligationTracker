using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Models.ViewModels
{
    public class LogInVM
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Required, DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
