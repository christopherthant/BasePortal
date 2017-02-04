using Teromac.Core.Domain.Users;

namespace Teromac.Services.Users
{
    /// <summary>
    /// User registration request
    /// </summary>
    public class UserRegistrationRequest
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="email">Email</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isApproved">Is approved</param>
        public UserRegistrationRequest(User user, string email, string username,
            string password,
            bool isApproved = true)
        {
            this.User = user;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.IsApproved = isApproved;
        }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Is approved
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
