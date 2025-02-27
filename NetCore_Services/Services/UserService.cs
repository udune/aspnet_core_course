using NetCore_Services.Interfaces;
using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;

namespace NetCore_Services.Services;

public class UserService : IUser
{
    #region private methods
    private IEnumerable<User> GetUserInfos()
    {
        return new List<User>()
        {
            new User()
            {
                UserId = "jadejs",
                Username = "김정수",
                UserEmail = "jadejs@gmail.com",
                Password = "123456"
            }
        };
    }

    private bool CheckTheUserInfo(string userId, string password)
    {
        return GetUserInfos().Any(user => user.UserId.Equals(userId) && user.Password.Equals(password));
    }
    #endregion

    public bool MatchTheUserInfo(LoginInfo login)
    {
        return CheckTheUserInfo(login.UserId, login.Password);
    }
}