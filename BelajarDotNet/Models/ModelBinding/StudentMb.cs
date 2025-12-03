namespace BelajarDotNet.Models.ModelBinding
{
    public class StudentMb
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public BranchMb? Branch { get; set; }
        public GenderMb? Gender { get; set; }
        public bool IsRegular { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}
