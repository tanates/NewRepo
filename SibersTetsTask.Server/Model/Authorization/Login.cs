using System.ComponentModel.DataAnnotations;

namespace SibersTetsTask.Server.Model.Authorization
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
