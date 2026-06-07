using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DemoExamRyzhov.Model
{
    public class MainRepository
    {
        // Товары (Products)
        // Вытягивание тотваров 
        public DataTable GetFilteredProducts(string search, string category, string manufacturer, string sort)
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT article, name, unit, price, supplier, manufacturer, category, discount, stock, description FROM products WHERE 1=1";

                if (!string.IsNullOrEmpty(category) && category != "Все категории")
                    query += " AND category = @category";

                if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все производители")
                    query += " AND manufacturer = @manufacturer";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (name ILIKE @search OR description ILIKE @search)";

                if (sort == "Стоимость (по возрастанию)")
                    query += " ORDER BY price ASC";
                else if (sort == "Стоимость (по убыванию)")
                    query += " ORDER BY price DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(category) && category != "Все categories")
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

        // Вытягивание категорий
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

        //Вытягивание производителей
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

        //Добавление товара
        public void AddProduct(string article, string name, string unit, decimal price, string supplier, string manufacturer, string category, int discount, int stock, string description)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO products (article, name, unit, price, supplier, manufacturer, category, discount, stock, description) 
                                 VALUES (@article, @name, @unit, @price, @supplier, @manufacturer, @category, @discount, @stock, @description)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("article", article);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("unit", unit);
                    cmd.Parameters.AddWithValue("price", price);
                    cmd.Parameters.AddWithValue("supplier", supplier);
                    cmd.Parameters.AddWithValue("manufacturer", manufacturer);
                    cmd.Parameters.AddWithValue("category", category);
                    cmd.Parameters.AddWithValue("discount", discount);
                    cmd.Parameters.AddWithValue("stock", stock);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление списка
        public void UpdateProduct(string article, string name, string unit, decimal price, string supplier, string manufacturer, string category, int discount, int stock, string description)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE products SET name=@name, unit=@unit, price=@price, supplier=@supplier, manufacturer=@manufacturer, 
                                 category=@category, discount=@discount, stock=@stock, description=@description WHERE article=@article";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("article", article);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("unit", unit);
                    cmd.Parameters.AddWithValue("price", price);
                    cmd.Parameters.AddWithValue("supplier", supplier);
                    cmd.Parameters.AddWithValue("manufacturer", manufacturer);
                    cmd.Parameters.AddWithValue("category", category);
                    cmd.Parameters.AddWithValue("discount", discount);
                    cmd.Parameters.AddWithValue("stock", stock);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление товара
        public void DeleteProduct(string article)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM products WHERE article = @article";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("article", article);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Заказы (Orders)
        // Вытягивание заказов из БД
        public DataTable GetOrders()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT o.order_number, o.order_date, o.delivery_date, 
                                        p.address as order_point_address, 
                                        u.full_name as client, o.status 
                                 FROM orders o
                                 LEFT JOIN delivery_points p ON o.delivery_point_id = p.id
                                 LEFT JOIN users u ON o.user_id = u.id";
                using (var adapter = new NpgsqlDataAdapter(query, conn)) { adapter.Fill(dt); }
            }
            return dt;
        }

        public List<string> GetOrderStatuses()
        {
            return new List<string> { "Новый", "Завершен", "Отменен" };
        }

        // Добавление заказа
        public void AddOrder(DateTime orderDate, DateTime deliveryDate, string pointAddress, string clientName, string status)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string pickupCode = new Random().Next(100, 1000).ToString();

                string query = @"INSERT INTO orders (order_number, order_date, delivery_date, delivery_point_id, user_id, pickup_code, status) 
                                 VALUES (
                                     (SELECT COALESCE(MAX(order_number), 0) + 1 FROM orders), 
                                     @orderDate, 
                                     @deliveryDate, 
                                     (SELECT id FROM delivery_points WHERE address = @address LIMIT 1), 
                                     (SELECT id FROM users WHERE full_name = @client LIMIT 1), 
                                     @pickupCode,
                                     @status
                                 )";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("orderDate", orderDate);
                    cmd.Parameters.AddWithValue("deliveryDate", deliveryDate);
                    cmd.Parameters.AddWithValue("address", pointAddress);
                    cmd.Parameters.AddWithValue("client", clientName);
                    cmd.Parameters.AddWithValue("pickupCode", pickupCode);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление списка
        public void UpdateOrder(int orderNumber, DateTime orderDate, string pointAddress, string status, DateTime? deliveryDate = null, string clientName = null)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Динамически строим запрос в зависимости от того, передали ли нам клиента и дату доставки
                string query = @"UPDATE orders 
                         SET order_date = @orderDate, 
                             delivery_point_id = (SELECT id FROM delivery_points WHERE address = @address LIMIT 1), 
                             status = @status";

                if (deliveryDate != null) query += ", delivery_date = @deliveryDate";
                if (!string.IsNullOrEmpty(clientName)) query += ", user_id = (SELECT id FROM users WHERE full_name = @client LIMIT 1)";

                query += " WHERE order_number = @orderNumber";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("orderDate", orderDate);
                    cmd.Parameters.AddWithValue("address", pointAddress);
                    cmd.Parameters.AddWithValue("status", status);

                    if (deliveryDate != null) cmd.Parameters.AddWithValue("deliveryDate", deliveryDate.Value);
                    if (!string.IsNullOrEmpty(clientName)) cmd.Parameters.AddWithValue("client", clientName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление заказа
        public void DeleteOrder(int orderNumber)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM orders WHERE order_number = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", orderNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Пункты выдачи (Delivey points)
        // Вытягивание ПВЗ из БД
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

        // Добавление ПВД
        public void AddDeliveryPoint(string address)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO delivery_points (address) VALUES (@address)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление списка
        public void UpdateDeliveryPoint(int id, string address)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE delivery_points SET address = @address WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление ПВЗ
        public void DeleteDeliveryPoint(int pointId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM delivery_points WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", pointId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Пользователи и клиенты (Users)
        // Вытягивание пользователей
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

        // Вытягивание клиентов
        public List<string> GetClients()
        {
            var clients = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT full_name FROM users ORDER BY full_name";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(reader["full_name"].ToString());
                    }
                }
            }
            return clients;
        }

        // Вытягивание ролей
        public List<string> GetRoleNames()
        {
            List<string> list = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT role_name FROM user_roles", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["role_name"].ToString());
                }
            }
            return list;
        }

        // Создание пользователей
        public void AddUser(string fullName, string login, string roleName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO users (full_name, login, password, role_id) 
                                 VALUES (@name, @login, '12345', (SELECT id FROM user_roles WHERE role_name = @role LIMIT 1))";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("name", fullName);
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("role", roleName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление списка
        public void UpdateUser(int id, string fullName, string login, string roleName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET full_name = @name, login = @login, role_id = (SELECT id FROM user_roles WHERE role_name = @role LIMIT 1) WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("name", fullName);
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("role", roleName);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление пользователей
        public void DeleteUser(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM users WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}