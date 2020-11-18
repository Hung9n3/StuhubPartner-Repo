using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StuhubPartner.Controller
{
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}
