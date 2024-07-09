using Infrastructure.Data;
using Services.Interfaces;
using Model.Base;

namespace Services;

public class UserService : IUser
{
    private readonly Context _context;

    public UserService(Context context)
    {
        _context = context;
    }
    public void AddUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }
    public List<User> Get()
    {
        return _context.User.ToList();
    }
}