using System.Collections.Generic;

#pragma warning disable CA2227

namespace Lecture9
{
    public class Dialog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserDialog> UserDialogs { get; set; }
    }
}
