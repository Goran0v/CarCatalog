using System.Security.Claims;
using static CarCatalog.Common.GeneralApplicationConstants;

namespace CarCatalog.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}
