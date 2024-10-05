using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}