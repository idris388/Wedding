using Microsoft.AspNetCore.Mvc;

namespace WeddingMert.Web.ViewComponents
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
