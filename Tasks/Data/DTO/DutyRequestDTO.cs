using Microsoft.AspNetCore.Identity;

namespace Tasks.API.Data.DTO
{
    public class DutyRequestDTO
    {
        public string title { get; set; }
        public string detail { get; set; }
        public DateTime dueDate { get; set; }
        public bool isCompleted { get; set; }
        public IdentityUser user { get; set; }
        
    }
}
