using System;
using System.Linq;

namespace Lecture9
{
    class Program
    {
        static void Main()
        {
            using var context = new ChatContext();

            {
                var user = new User { Login = "Victoria", Password = "SHA-128" };
                Console.WriteLine(context.Entry(user).State);

                context.Add(user);
                Console.WriteLine(context.Entry(user).State);

                context.SaveChanges();
                Console.WriteLine(context.Entry(user).State);

                user.Password = "SHA-256";
                Console.WriteLine(context.Entry(user).State);

                context.SaveChanges();
                Console.WriteLine(context.Entry(user).State);

                context.Remove(user);
                Console.WriteLine(context.Entry(user).State);

                context.SaveChanges();
                Console.WriteLine(context.Entry(user).State);
            }

            {
                string login = "Ivan";

                var user = context.Users.Where(e => e.Login == login).Single();
                Console.WriteLine(user.Id);

                context.Entry(user).Collection(nameof(user.UserDialogs)).Load();
                foreach (var userDialog in user.UserDialogs)
                {
                    context.Entry(userDialog).Reference(nameof(userDialog.Dialog)).Load();
                    Console.WriteLine(userDialog.Dialog.Name);
                }

                var dialogIds = context.UserDialogs.Where(e => e.UserId == user.Id).Select(e => e.DialogId);
                Console.WriteLine(string.Join(' ', dialogIds));

                var dialogNames = context.Dialogs.Where(e => dialogIds.Contains(e.Id)).Select(e => e.Name);
                Console.WriteLine(string.Join(Environment.NewLine, dialogNames));
            }
        }
    }
}
