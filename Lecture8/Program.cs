using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Lecture8
{
    class Program
    {
        static void Main()
        {
            // TODO: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
            var connectionString = $"Datasource=localhost; Database=chat; User=root; Password=password";
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            connection.CreateCommand();

            FindUserIdByLoginAndPassword(connection, "Maria", "SHA-256", out var foundId);

            if (!AddUser(connection, "Marina", "SHA-512", out var id))
                return;
            Console.WriteLine(id);
            Console.WriteLine($"{nameof(UpdatePassword)}: {UpdatePassword(connection, id, "SHA-128")}");

            var dialogIdList = string.Join(' ', GetDialogIdList(connection, id));
            Console.WriteLine($"{nameof(GetDialogIdList)}: {dialogIdList}");

            Console.WriteLine($"{nameof(DeleteUser)}: {DeleteUser(connection, id)}");

        }

        private static bool FindUserIdByLoginAndPassword(MySqlConnection connection, string login, string password, out int id)
        {
            // TODO Пароль хранить в виде хеша

            id = default;

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT `id` FROM `users` WHERE `login` = @{nameof(login)} AND `password` = @{nameof(password)};";
            command.Parameters.AddWithValue(nameof(login), login);
            command.Parameters.AddWithValue(nameof(password), password);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                id = reader.GetInt32("id");
                return true;
            }

            return false;
        }

        private static List<int> GetDialogIdList(MySqlConnection connection, int userId)
        {
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT `dialog_id` FROM `user_dialogs` WHERE `user_id` = @{nameof(userId)};";
            command.Parameters.AddWithValue(nameof(userId), userId);

            using var reader = command.ExecuteReader();
            var dialogIdList = new List<int>();
            while (reader.Read())
                dialogIdList.Add(reader.GetInt32("dialog_id"));

            return dialogIdList;
        }

        private static bool AddUser(MySqlConnection connection, string login, string password, out int id)
        {
            // TODO Пароль хранить в виде хеша

            id = default;

            using var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO `users` (`login`, `password`) VALUES (@{nameof(login)}, @{nameof(password)});";
            command.Parameters.AddWithValue(nameof(login), login);
            command.Parameters.AddWithValue(nameof(password), password);

            try
            {
                if (command.ExecuteNonQuery() != 1)
                    return false;
                id = (int)command.LastInsertedId;
                return true;
            }
            catch (MySqlException exc) when (exc.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
            {
                return false;
            }
        }

        private static bool UpdatePassword(MySqlConnection connection, int id, string newPassword)
        {
            // TODO Пароль хранить в виде хеша

            using var command = connection.CreateCommand();
            command.CommandText = $"UPDATE `users` SET `password` = @{nameof(newPassword)} WHERE `id` = @{nameof(id)};";
            command.Parameters.AddWithValue(nameof(id), id);
            command.Parameters.AddWithValue(nameof(newPassword), newPassword);
            return command.ExecuteNonQuery() == 1;
        }

        private static bool DeleteUser(MySqlConnection connection, int id)
        {
            using var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM `users` WHERE id = @{nameof(id)};";
            command.Parameters.AddWithValue(nameof(id), id);
            return command.ExecuteNonQuery() == 1;
        }
    }
}
