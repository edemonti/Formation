using System.Web.Mvc;
using Elements.MVC.Models;

namespace Elements.MVC.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        // Il faut activer MapMvcAttributeRoutes au niveau du RouteConfi pour pouvoir créer des routes personnalisées.
        [Route("lire/{id}/{title}")]
        public ActionResult Lire(LireModel model)
        {
            //var model = new LireModel
            //{
            //    ID = id,
            //    Title = title.Replace('-', ' ')
            //};

            //var articleTitle = Request.Params["title"];
            //ViewBag.ArticleId = id;
            //ViewBag.ArticleTitle = articleTitle?.Replace('-', ' ');
            return View(model);
        }

        // GET: Article
        //[Route("all"), Route("tous")]
        //[Route("all")]
        //[Route("tous")]
        [Route("{Type:regex(all|tous|oui)}")]
        public ActionResult AllArticles()
        {
            return View();
        }
    }
}