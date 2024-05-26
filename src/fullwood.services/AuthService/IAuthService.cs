using fullwood.domain.Entities;

namespace fullwood.services.AuthService
{
    public interface IAuthService
    {
        Task SignInAsync(LoginModel loginModel);
    }
}
