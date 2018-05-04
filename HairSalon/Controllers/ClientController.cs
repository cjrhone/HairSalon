using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/stylists/{stylistId}/client/new")]
    public ActionResult CreateForm(int stylistId)
    {
      Dictionary<string, object>model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
        Item.ClearAll();
        return View();
    }
  }
}
