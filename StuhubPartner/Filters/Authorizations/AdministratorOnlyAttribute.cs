using Microsoft.AspNetCore.Authorization;
using Repository;

namespace StuhubPartner.Filters.Authorizations
{
    public sealed class AdministratorOnlyAttribute : AuthorizeAttribute
    {
        public AdministratorOnlyAttribute()
        {
            Roles = Constants.Roles.Administrator;
        }
    }
}
