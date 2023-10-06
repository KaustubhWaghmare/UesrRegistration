using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = " The Email Field is Required")]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = " The Gender Field is Required")]
        public string Gender { get; set;}

        [Required(ErrorMessage = "The Address Field is Required")]
        public string Address { get; set;}

        [Required(ErrorMessage = "The Contact Number Field is Required")]
        public string ContactNumber { get; set;}

    }
}
