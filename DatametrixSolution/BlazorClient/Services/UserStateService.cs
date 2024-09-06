
using System.Security.Claims;
using System.Threading.Tasks;

public class UserStateService
{
    public ClaimsPrincipal CurrentUser { get; private set; }

    public void SetUser(ClaimsPrincipal user)
    {
        CurrentUser = user;
    }

    public string GetUserName()
    {
        return CurrentUser?.FindFirst(ClaimTypes.Name)?.Value;
    }

    public string GetUserRole()
    {
        return CurrentUser?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
