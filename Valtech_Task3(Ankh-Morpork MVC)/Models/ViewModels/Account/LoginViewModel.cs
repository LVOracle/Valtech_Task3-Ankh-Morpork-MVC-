using System.ComponentModel.DataAnnotations;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}