using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Module
{
    public class TaskModel
    {
        public int Id { get; set; }  // int is non-nullable by default

        [Required]  // This makes it non-nullable and must have a value
        public string Name { get; set; } = string.Empty; // Ensuring default non-null value

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }  // DateTime is non-nullable by default

        [Required]
        public string Priority { get; set; } = "Low";  // Priority defaults to "Low" but is non-nullable

        public bool IsCompleted { get; set; }  // bool is non-nullable by default
    }
}
