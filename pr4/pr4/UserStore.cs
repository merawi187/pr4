using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace pr4
{
    public static class UserStore
    {
        private static Dictionary<string, User> users = new Dictionary<string, User>();
        
        public static bool RegisterUser(string username, string password, string role)
        {
            if (users.ContainsKey(username))
            {
                return false;
            }
            string passwordHash = HashPassword(password);
            users[username] = new User(username, passwordHash, role);
            return true;
        }
        public static string GetUserRole(string username)
        {
            if (users.TryGetValue(username, out User user)) 
            { 
                return user.Role; 
            }
            return null;
        }
        public static bool ValidateUser(string username, string password)
        {
            if (users.TryGetValue(username, out User user))
            {
                return user.PasswordHash == HashPassword(password);
            }
            return false;
        }
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
