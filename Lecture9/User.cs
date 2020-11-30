using System.Collections.Generic;

#pragma warning disable CA2227

namespace Lecture9
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public List<UserDialog> UserDialogs { get; set; }
    }
}
