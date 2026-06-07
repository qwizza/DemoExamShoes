using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.Model
{
    public enum UserRole
    {
        Guest,
        Client,
        Manager,
        Admin
    }

    // Статический класс, доступный из любой точки программы
    public static class UserSession
    {
        public static UserRole CurrentRole { get; set; } = UserRole.Guest;
        public static string FullName { get; set; } = "Гость";
        public static int? UserId { get; set; }
    }
}
