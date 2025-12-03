using BelajarDotNet.Models;

namespace BelajarDotNet.ViewModels
{
    public class StudentDetailsViewModel
    {
        public StudentMVC? Student { get; set; }
        public AddressMVC? Address { get; set; }
        public string? Title { get; set; }
        public string? Header { get; set; }

    }
}
