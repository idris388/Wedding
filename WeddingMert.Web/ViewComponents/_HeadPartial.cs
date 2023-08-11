using Microsoft.AspNetCore.Mvc;

namespace WeddingMert.Web.ViewComponents
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
