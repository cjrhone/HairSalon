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
            Stylist newCategory = new Stylist(Request.Form["stylist-name"]);
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }


        [HttpPost("/clients")]
        public ActionResult CreateItem()
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist foundStylist = Stylist.Find(Int32.Parse(Request.Form["stylist-id"]));
          string clientName = Request.Form["client-name"];
          Client newClient = new Client(clientName);
          // foundStylist.AddClient(newClient);
          List<Client> stylistClients = foundStylist.GetClients();
          model.Add("clients", stylistClients);
          model.Add("stylist", foundStylist);
          return View("Details", model);
        }
    }
}
