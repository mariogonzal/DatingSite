using System.ComponentModel.DataAnnotations;

namespace DatingSite.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8,MinimumLength=4, ErrorMessage="you must specify password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}