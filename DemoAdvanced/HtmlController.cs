using Microsoft.AspNetCore.Mvc;

namespace Streaming.DemoAdvanced;

public class HtmlController : Controller
{
    [HttpGet("demo")]
    public IActionResult Demo()
    {
        return View("~/DemoAdvanced/Demo.cshtml");
    }
}