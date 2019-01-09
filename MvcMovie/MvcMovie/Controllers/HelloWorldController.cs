using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return View();
        }

        public string Welcome(string name, int id=1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, id is : {id}");
        }
    }
}