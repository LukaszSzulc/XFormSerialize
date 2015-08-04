using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebApplication4.Binders;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        [HttpPost]
        public void Index([ModelBinder(typeof(FormModelBinder))]PaymentModel form)
        {
        }
    }
}