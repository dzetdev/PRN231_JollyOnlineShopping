using JollyAPI.Models.DTO.User;
using JollyAPI.Models.Entity;

namespace JollyAPI.DAO
{
    public class UserDAO
    {
        private readonly JollyShoppingOnlineContext _context;

        public UserDAO(JollyShoppingOnlineContext jollyShoppingOnlineContext )
        {
            _context = jollyShoppingOnlineContext;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<UserDTO> GetAllUsers() => _context.Users.Where(x => x.Role.Equals("user")).Select(u => new UserDTO
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email,
            Password = u.Password,
            Phone = u.Phone,
            Status = (bool)u.Status
        }).ToList();

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
