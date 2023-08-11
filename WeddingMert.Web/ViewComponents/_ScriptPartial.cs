using Microsoft.AspNetCore.Mvc;

namespace WeddingMert.Web.ViewComponents
{
    public class _ScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
