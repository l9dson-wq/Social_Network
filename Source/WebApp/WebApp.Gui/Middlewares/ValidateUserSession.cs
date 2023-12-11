using Core.Application;

namespace WebApp.Gui.Middlewares;

public class ValidateUserSession
{
    private readonly IHttpContextAccessor _iHttpContextAccesor;

    public ValidateUserSession(IHttpContextAccessor iHttpContextAccesor)
    {
        _iHttpContextAccesor = iHttpContextAccesor;
    }

    public bool HasUser()
    {
        UserProfileViewModel userProfileViewModel = _iHttpContextAccesor.HttpContext.Session.Get<UserProfileViewModel>("userProfile");

        if (userProfileViewModel == null)
        {
            return false;
        }

        return true;
    }
}