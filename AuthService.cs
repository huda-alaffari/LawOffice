using System.Threading.Tasks;

namespace LowOffice
{
    public class AuthService
    {
        // Add this method to fix CS1061
        public async Task<bool> CheckLogin(string email, string password)
        {
            // Replace with actual authentication logic
            await Task.Delay(100); // Simulate async work
                                   // Example: return true if email and password are not empty
            return !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
        }
    }
}