using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }


        /*
            1) når en form bliver submitted med et HttpPost, så bliver den routet her
            2) fordi vi bruger form a type AuthLogin, så prøver den at matche props fra formen
            til denne classes props.
            3) 'value' værdien i formens submit er vigtig, det er den der peger hertil 
        */
        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if ( !ModelState.IsValid)
            {
                // return Content("Hi there, " + form.Username);
                return View(form);
            }

            //we can add our own custom error msgs as well:
            if( form.Username == "foo bar" )
            {
                ModelState.AddModelError("Username", "This username is not allowed");
                return View(form);
            }

            return Content("The form is valid");

        }
    }
}