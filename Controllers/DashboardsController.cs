using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class DashboardsController : Controller
{
  // public IActionResult Index() => View();
  public IActionResult Index()
  {
    return View("~/Views/Dashboards/Index.cshtml");
  }

}
