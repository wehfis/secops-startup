using System.Collections.Generic;

namespace BLL.Core.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }
        public ICollection<UserDialog> UserDialogs { get; set; }
    }
}
