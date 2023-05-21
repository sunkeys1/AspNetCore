using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspCoreMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6,ErrorMessage = "Length of login should be more than 5 symbols")]
        [DisplayName("Login")]
        public string Login { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8,ErrorMessage = "Length of password should be more than 7 symbols")]
        [DisplayName("Password")]
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public int GroupId { get; set; }
        
        [DisplayName("State")]
        public string? UserState { get; set; }

    }
}
