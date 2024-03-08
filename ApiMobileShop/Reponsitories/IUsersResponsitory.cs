using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IUsersResponsitory
    {
        List<User> GetUsers();
        User GetUserById(int UserId);
        void AddUser(User usermodel);
        void UpdateUser(User usermodel);
        void DeleteUser(int UserId);
    }
}
