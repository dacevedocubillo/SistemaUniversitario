using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SistUniversitario.Models;

namespace SistUniversitario.Filters
{
    /// <summary>
    /// Protege todas las pantallas privadas y permite limitar acciones al administrador.
    /// </summary>
    public sealed class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public bool AdministratorOnly { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AllowsAnonymousAccess(filterContext))
            {
                return;
            }

            HttpSessionStateBase session = filterContext.HttpContext.Session;
            bool loggedIn = session["logueado"] is bool && (bool)session["logueado"];
            RetornaUsuarioCorreoPwd_Result user = session["datosusuario"] as RetornaUsuarioCorreoPwd_Result;

            if (!loggedIn || user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "LogIn",
                    action = "Index",
                    returnUrl = filterContext.HttpContext.Request.RawUrl
                }));
                return;
            }

            if (AdministratorOnly && !string.Equals(user.Tipo_Usuario, "Administrador", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.Result = new HttpStatusCodeResult(403, "Esta operación requiere permisos de administrador.");
                return;
            }

            bool isConsultant = string.Equals(user.Tipo_Usuario, "Consultor", StringComparison.OrdinalIgnoreCase);
            bool changesData = !string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(filterContext.HttpContext.Request.HttpMethod, "HEAD", StringComparison.OrdinalIgnoreCase);
            if (isConsultant && changesData)
            {
                filterContext.Result = new HttpStatusCodeResult(403, "El perfil consultor solo puede visualizar información.");
            }
        }

        private static bool AllowsAnonymousAccess(ActionExecutingContext context)
        {
            return context.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || context.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
        }
    }
}
