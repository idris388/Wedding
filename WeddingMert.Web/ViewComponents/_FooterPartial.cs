using Microsoft.AspNetCore.Mvc;

namespace WeddingMert.Web.ViewComponents
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
