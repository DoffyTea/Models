using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class Model
    {
        [Display(Name = "Введите имя или логин")]
        [Required(ErrorMessage = "Введите данные")]
        public string Login { get; set; }

        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Введите данные")]
        public string Email { get; set; }

        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Введите данные")]
        public int Age { get; set; }

        [Display(Name = "Введите пароль")]
        [StringLength(8, ErrorMessage ="Не более 8 символов")]
        [Required(ErrorMessage = "Введите данные")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [Required(ErrorMessage = "Введите данные")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string CheckedPassword { get; set; }
    }
}
