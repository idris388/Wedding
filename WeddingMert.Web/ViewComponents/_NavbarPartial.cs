using Microsoft.AspNetCore.Mvc;

namespace WeddingMert.Web.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
