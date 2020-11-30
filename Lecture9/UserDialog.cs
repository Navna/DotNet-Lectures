using System.ComponentModel.DataAnnotations.Schema;

namespace Lecture9
{
    [Table("user_dialogs")]
    public class UserDialog
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("dialog_id")]
        public int DialogId { get; set; }

        public User User { get; set; }

        public Dialog Dialog { get; set; }
    }
}
