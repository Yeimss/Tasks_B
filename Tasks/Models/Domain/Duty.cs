using Microsoft.AspNetCore.Identity;

namespace Tasks.Models.Domain
{
    public class Duty
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public DateTime dueDate { get; set; }
        public bool isCompleted { get; set; }
        public IdentityUser user { get; set; }
    }
}
