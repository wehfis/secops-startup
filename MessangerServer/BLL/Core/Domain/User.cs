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
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserRole? Role { get; set; }
        public ICollection<Dialog> Dialogs { get; } = new List<Dialog>();
    }
}
