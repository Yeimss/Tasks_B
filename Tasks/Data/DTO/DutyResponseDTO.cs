using Microsoft.AspNetCore.Identity;

namespace Tasks.API.Data.DTO
{
    public class DutyResponseDTO
    {
        public string title { get; set; }
        public string message { get; set; }
        public string operation { get; set; }
        public bool statusOperation { get; set; }
        public DutyResponseDTO() { }
        public DutyResponseDTO(string title, string message, string operation, bool statusOperation)
        {
            this.title = title;
            this.message = message;
            this.operation = operation;
            this.statusOperation = statusOperation;
        }
    }
}
