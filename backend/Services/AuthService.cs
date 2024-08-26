using AgileFlowMobile.backend.Model;

namespace AgileFlowMobile.backend.Services
{
    public class AuthService
    {
        // Simula uma lista de usuários cadastrados
        private static readonly List<User> Users = new List<User>
        {
            new User { Email = "teste1", Password = "123" },
            new User { Email = "teste2", Password = "123" },
            new User { Email = "teste3", Password = "123" }
        };

        // Autenticação de login
        public Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            return Task.FromResult(user != null);
        }

        // Verificação se o e-mail já existe
        public Task<bool> CheckIfEmailExistsAsync(string email)
        {
            var userExists = Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(userExists);
        }

        // Registro de um novo usuário
        public Task<bool> RegisterUserAsync(string email, string password)
        {
            if (Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(false);
            }

            Users.Add(new User { Email = email, Password = password });
            return Task.FromResult(true);
        }
    }
}
