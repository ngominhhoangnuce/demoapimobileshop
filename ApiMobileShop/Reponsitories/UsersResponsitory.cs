using ApiMobileShop.Data;
using ApiMobileShop.Models;

namespace ApiMobileShop.Reponsitories
{
    public class UsersResponsitory : IUsersResponsitory
    {
        private readonly MobileContext _shopuser;

        public UsersResponsitory(MobileContext shopuser)
        {
            _shopuser = shopuser;
        }

        public List<User> GetUsers()
        {
            return _shopuser.Users.ToList();
        }

        public User GetUserById(int UserId)
        {
            return _shopuser.Users.Find(UserId);
        }

        public void AddUser(User usermodel)
        {
            _shopuser.Users.Add(usermodel);
            _shopuser.SaveChanges();
        }

        public void UpdateUser(User usermodel)
        {
            var ExistingUser = _shopuser.Users.Find(usermodel.UserId);

            if (ExistingUser != null)
            {
                // Cập nhật thông tin người dùng
                ExistingUser.FirstName = usermodel.FirstName;
                ExistingUser.LastName = usermodel.LastName;
                ExistingUser.Email = usermodel.Email;
                ExistingUser.BirthDate = usermodel.BirthDate;
                ExistingUser.Gender = usermodel.Gender;
                ExistingUser.CompanyAddress = usermodel.CompanyAddress;
                ExistingUser.HomeAddress = usermodel.HomeAddress;

                _shopuser.SaveChanges();
            }
        }

        public void DeleteUser(int UserId)
        {
            var UserToDelete = _shopuser.Users.Find(UserId);

            if (UserToDelete != null)
            {
                _shopuser.Users.Remove(UserToDelete);
                _shopuser.SaveChanges();
            }
        }
    }
}
