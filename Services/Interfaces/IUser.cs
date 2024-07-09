using Model.Base;

namespace Services.Interfaces;

public interface IUser
{
    void AddUser(User user);
    List<User> Get();
}