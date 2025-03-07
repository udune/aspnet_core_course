using Microsoft.EntityFrameworkCore;
using NetCore_Data.DataModels;
using NetCore_Data.ViewModels;
using NetCore_Services.Data;
using NetCore_Services.Interfaces;

namespace NetCore_Services.Services;

public class UserService : IUser
{
    private CodeFirstDbContext _context;
    
    public UserService(CodeFirstDbContext context)
    {
        _context = context;
    }
    
    #region private methods
    private IEnumerable<User> GetUserInfos()
    {
        return _context.Users.ToList();
        
        // return new List<User>()
        // {
        //     new User()
        //     {
        //         UserId = "jadejs",
        //         Username = "김정수",
        //         UserEmail = "jadejs@gmail.com",
        //         Password = "123456"
        //     }
        // };
    }

    private User GetUserInfo(string userId, string password)
    {
        User user;
        //user = _context.Users.Where(user => user.UserId.Equals(userId) && user.Password.Equals(password)).FirstOrDefault();
        
        user = _context.Users
            .FromSql($"SELECT UserId, UserName, UserEmail, Password, IsMembershipWithdrawn, JoinedUtcDate FROM dbo.Users")
            .FirstOrDefault(user => user.UserId.Equals(userId) && user.Password.Equals(password));
        
        return user;
    }
    
    private bool CheckTheUserInfo(string userId, string password)
    {
        return GetUserInfo(userId, password) != null ? true : false;
    }
    #endregion

    public bool MatchTheUserInfo(LoginInfo login)
    {
        return CheckTheUserInfo(login.UserId, login.Password);
    }
}