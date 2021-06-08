using System.Linq;

namespace VehicleDealership.Domain.Helpers
{
    public class ValidationHelper
    {
        public static bool ValidateUsername(string username)
        {
            return username.Length >= 6 && username.Any(x => char.IsUpper(x));
        }

        public static bool ValidatePassword(string password)
        {
            return password.Length > 6 && password.Any(x => char.IsDigit(x)) && password.Any(x => char.IsUpper(x));
        }
    }
}
