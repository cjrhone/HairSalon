using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {

        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create()
        {
            Stylist newCategory = new Stylist(Request.Form["category-name"]);
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Item> stylistClients = selectedStylist.GetItems();
            model.Add("category", selectedStylist);
            model.Add("items", stylistClients);
            return View(model);
        }


        [HttpPost("/items")]
        public ActionResult CreateItem()
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist foundCategory = Stylist.Find(Int32.Parse(Request.Form["category-id"]));
          string itemDescription = Request.Form["item-description"];
          Item newItem = new Item(itemDescription);
          foundCategory.AddItem(newItem);
          List<Item> stylistClients = foundCategory.GetItems();
          model.Add("items", stylistClients);
          model.Add("category", foundCategory);
          return View("Details", model);
        }
    }
}
