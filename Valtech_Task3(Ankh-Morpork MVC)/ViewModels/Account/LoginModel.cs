using System.ComponentModel.DataAnnotations;

namespace Valtech_Task3_Ankh_Morpork_MVC_.ViewModels.Account
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType((DataType.Password))]
        public string Password { get; set; }
    }
}