using System.Collections.Generic;

namespace BLL.Core.Domain
{
    public enum UserRole
    {
        Admin,
        Moderator,
        User
    }
    public class User
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Dialog> Dialogs { get; } = new List<Dialog>();
    }
}
