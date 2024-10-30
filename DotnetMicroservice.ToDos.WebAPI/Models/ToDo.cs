namespace DotnetMicroservice.ToDos.WebAPI.Models
{
    public sealed class ToDo
    {
        public int Id { get; set; }
        public string Work { get; set; } = default!;
        public bool IsCompleted { get; set; } = false;
    }
}
