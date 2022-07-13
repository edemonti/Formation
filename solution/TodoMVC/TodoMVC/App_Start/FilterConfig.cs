using System.Web;
using System.Web.Mvc;

namespace TodoMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // Permet d’afficher la fenêtre de login si aucun user n’est connecté (pour tous les controllers).
        }
    }
}
