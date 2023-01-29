using System.Threading.Tasks;
using NSomeWorks.Model;

namespace NSomeWorks.Services.Abstractions;
public interface IAuthenticationService
{
    Task<LoginResult> Login(string login, string password);
    Task<RegisterResult> Register(string login, string password);
}
