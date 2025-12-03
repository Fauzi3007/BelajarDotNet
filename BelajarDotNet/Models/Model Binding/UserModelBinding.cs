using System.ComponentModel.DataAnnotations;

namespace BelajarDotNet.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string UserEmail { get; set; }
    }
}