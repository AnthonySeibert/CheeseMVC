using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using My_Third_MVC_App.Models;

namespace My_Third_MVC_App.Controllers;

public class CheeseController : Controller
{
    static private IDictionary<string, string> Cheeses = new Dictionary<string, string>();
    public IActionResult Index()
    {

        ViewBag.cheeses = Cheeses;

        return View();
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    [Route("/Cheese/Add")]
    public IActionResult NewCheese(string name, string description)
    {
        Cheeses.Add(name, description);
        return Redirect("/Cheese");
    }

     public IActionResult Remove()
    {
        ViewBag.Cheeses = Cheeses;
        return View();
    }
     [HttpPost]
    [Route("/Cheese/Remove")]
    public IActionResult RemoveCheese(string[] Cheese)
    {
        foreach(string cheese in Cheese)
            Cheeses.Remove(cheese);
        return Redirect("/Cheese");
    }
}
