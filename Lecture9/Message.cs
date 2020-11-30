using System;

namespace Lecture9
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DialogId { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }
    }
}
