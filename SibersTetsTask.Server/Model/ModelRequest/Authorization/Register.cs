using System.ComponentModel.DataAnnotations;

namespace SibersTetsTask.Server.Model.ModelRequest.Authorization
{
    public class Register
    {

        [Required(ErrorMessage = "Введите имя ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пороль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
