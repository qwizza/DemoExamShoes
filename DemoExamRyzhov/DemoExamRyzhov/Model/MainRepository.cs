using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.Model
{
    public class MainRepository
    {
        // Метод получения товаров с динамической фильтрацией, поиском и сортировкой
        public DataTable GetFilteredProducts(string search, string category, string manufacturer, string sort)
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Базовый запрос
                string query = "SELECT article, name, unit, price, supplier, manufacturer, category, discount, stock, description FROM products WHERE 1=1";

                // Динамически добавляем условия фильтрации
                if (!string.IsNullOrEmpty(category) && category != "Все категории")
                    query += " AND category = @category";

                if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все производители")
                    query += " AND manufacturer = @manufacturer";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (name ILIKE @search OR description ILIKE @search)";

                // Добавляем сортировку по цене
                if (sort == "Стоимость (по возрастанию)")
                    query += " ORDER BY price ASC";
                else if (sort == "Стоимость (по убыванию)")
                    query += " ORDER BY price DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(category) && category != "Все категории")
                        cmd.Parameters.AddWithValue("category", category);

                    if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все производители")
                        cmd.Parameters.AddWithValue("manufacturer", manufacturer);

                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("search", "%" + search + "%");

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Получение уникальных категорий для комбобокса
        public List<string> GetCategories()
        {
            List<string> list = new List<string> { "Все категории" };
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT DISTINCT category FROM products WHERE category IS NOT NULL", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["category"].ToString());
                }
            }
            return list;
        }

        // Получение уникальных производителей для комбобокса
        public List<string> GetManufacturers()
        {
            List<string> list = new List<string> { "Все производители" };
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT DISTINCT manufacturer FROM products WHERE manufacturer IS NOT NULL", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["manufacturer"].ToString());
                }
            }
            return list;
        }

        // Простые методы получения остальных таблиц
        public DataTable GetOrders()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT o.order_number, o.order_date, o.delivery_date, p.address as delivery_point, u.full_name as client, o.status 
                                 FROM orders o
                                 LEFT JOIN delivery_points p ON o.delivery_point_id = p.id
                                 LEFT JOIN users u ON o.user_id = u.id";
                using (var adapter = new NpgsqlDataAdapter(query, conn)) { adapter.Fill(dt); }
            }
            return dt;
        }

        public DataTable GetDeliveryPoints()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var adapter = new NpgsqlDataAdapter("SELECT id, address FROM delivery_points", conn)) { adapter.Fill(dt); }
            }
            return dt;
        }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT u.id, u.full_name, u.login, r.role_name FROM users u JOIN user_roles r ON u.role_id = r.id";
                using (var adapter = new NpgsqlDataAdapter(query, conn)) { adapter.Fill(dt); }
            }
            return dt;
        }
    }
}
