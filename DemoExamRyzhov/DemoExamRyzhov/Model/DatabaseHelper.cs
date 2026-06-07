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
        //Подключаю БД
        private static readonly string ConnectionString = "Host = localhost; Username=postgres;Password=123456;Database=DemoExamRyzhov";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
