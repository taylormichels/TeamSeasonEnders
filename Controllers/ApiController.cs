using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSeasonEnders.Models;

namespace TeamSeasonEnders.Controllers
{
    public class ApiController : Controller
    {
        //
        // GET: /Api/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetTeams(string division)
        {
            using (TeamSeasonEndersEntities context = new TeamSeasonEndersEntities())
            {
                return Json(context.Teams.Where(t => t.Division == division));
            }
        }
    }
}
