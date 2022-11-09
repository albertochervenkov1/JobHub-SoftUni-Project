using System.ComponentModel.DataAnnotations;
using JobHub.Infrastructure.Common;

namespace JobHub.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        [Required]
        [StringLength(UserConstraints.FIRST_NAME_MAX_LENGTH, MinimumLength = UserConstraints.FIRST_NAME_MIN_LENGTH)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserConstraints.LAST_NAME_MAX_LENGTH, MinimumLength = UserConstraints.LAST_NAME_MIN_LENGTH)]
        public string LastName { get; set; } = null!;
    }
}
