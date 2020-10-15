using System.ComponentModel.DataAnnotations;

namespace AuthenticationJWT.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        [MinLength(3, ErrorMessage = "This field must contain more 3 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public string Role { get; set; }
    }
}