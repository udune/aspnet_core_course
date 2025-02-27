using NetCore.Data.ViewModels;

namespace NetCore_Services.Interfaces;

public interface IUser
{
    bool MatchTheUserInfo(LoginInfo login);
}