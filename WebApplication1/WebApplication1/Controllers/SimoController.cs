using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [HandleError()]
    public class SimoController : Controller
    {

        public string SayHi() {
            return "Hi";
        }

        //[HandleError(ExceptionType ='', View ="")]
        //[HandleError(ExceptionType = Type2, View = "gfdfgfdg")]
        public ViewResult SayHiWithView()
        {
            return View() ;
        }

        
        public ViewResult SayHiWithViewBag()
        {


            ViewBag.Stuff = "Oh hi!";
            return View();
        }

        [OutputCache()]
        public ActionResult AjaxDemo() {
            return View();
        }

        public ActionResult AjaxAction()
        {
            //object result = System.Runtime.Caching.MemoryCache.Default
            //    .AddOrGetExisting("whatever",new Person() { })

            return View();
        }
    }
}