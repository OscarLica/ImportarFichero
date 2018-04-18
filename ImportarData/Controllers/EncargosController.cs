using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImportarData.BL;
using System.Net;

namespace ImportarData.Controllers
{
    public class EncargosController : Controller
    {
        Context.Context db = new Context.Context();
        // GET: Encargos
        public ActionResult Index()
        {
            return View(db.Encargos.ToList());
        }
        [HttpPost]
        public ActionResult Post(HttpPostedFileBase file, int fComienzo)
        {
            if (file != null)
            {
                if (fComienzo >= 2)
                {
                    if (!new BL.Encargos().validaArchivo(file))
                    {
                        ViewBag.mensaje = "Error : Archivo incorrecto o dañanado";
                    }
                    else
                    {
                        new BL.Encargos().Savefile(file, fComienzo);
                    }
                }
            }
            else
            {
                ViewBag.mensaje = "no ha cargado ningun archivo";
            }

            return View("Index");
        }
    }
}