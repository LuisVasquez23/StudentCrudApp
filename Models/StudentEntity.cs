namespace StudentCrudApp.Models
{
    public class StudentEntity
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
    }
}
