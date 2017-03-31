using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CComplex.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["operador"] = "";
            return View();
        }
        
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {
            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (visor.Equals("0"))
                        visor = bt;
                    else
                        visor += bt;
                    break;
                case "C":
                    visor = "0";
                    break;
                case "x":
                case "+":
                case "-":
                case ":":
                    if ((string)Session["operador"] == "")
                    {
                        Session["operando"] = visor;
                        Session["operador"] = bt;
                    }
                    break;
                case "=":
                    break;
                case "+/-":
                    visor = (visor[0] == '-') ? (visor.Substring(1)) : ("-" + visor); 
                    break;
                case ",":
                    if(!visor.Contains(";"))
                        visor = visor + ",";
                    break;
            }
            //enviar dados para a view.
            ViewBag.Visor = visor;
            return View();
        }
    }
}