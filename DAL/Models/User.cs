using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
