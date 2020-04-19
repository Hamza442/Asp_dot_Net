using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{//Go to Global.asax
    //in web.config we have done this  <trace enable="true" pageOutput="false" ></trace> watch vedios on tracing
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //this is List method so its return type is also a list
        public ActionResult Index()
        {   //viewbag is also used to pass data from controller to view
            //we are storing the list in viewbag object which we gave by our self this is a dynamic expression
            ViewBag.Countries = new List<string> { 
            "PAk",
            "US",
            "UK",
            "Canada"
            };
            ViewData["Cities"] = new List<string>
            {
                "Lahore",
                "Karachi",
                "Islamabad"
            };
            //this will return view of index
            //the return type is View but our method is ActionResult , it is able to return View beacuse View is Inherting from ActionResult if you go to definition of view you can see that 
            return View();
        }

    }
}