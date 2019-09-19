using CommunityShedMVC.Security;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
    }
}