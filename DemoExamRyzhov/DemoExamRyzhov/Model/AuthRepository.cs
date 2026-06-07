using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov.Model
{
    public class AuthRepository
    {
        // Проверяю учетные данные пользователя в БД.
        public (bool isSuccess, string roleName, string fullName, int? userId) ValidateUser(string login, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Соединяет пользователей с их ролями
                    string query = @"
                        SELECT u.id, u.full_name, r.role_name 
                        FROM users u
                        JOIN user_roles r ON u.role_id = r.id
                        WHERE u.login = @login AND u.password = @password";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("login", login);
                        cmd.Parameters.AddWithValue("password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string fullName = reader["full_name"].ToString();
                                string role = reader["role_name"].ToString();

                                return (true, role, fullName, id);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка БД: " + ex.Message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return (false, null, null, null);
        }
    }
}
