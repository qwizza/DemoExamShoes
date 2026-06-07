using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.Model
{
    public static class DatabaseHelper
    {
        // ВНИМАНИЕ: Замени параметры Host, Username, Password, Database на свои актуальные!
        private static readonly string ConnectionString = "Host = localhost; Username=postgres;Password=123456;Database=DemoExamRyzhov";

        /// <summary>
        /// Возвращает готовое к открытию подключение к PostgreSQL
        /// </summary>
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
