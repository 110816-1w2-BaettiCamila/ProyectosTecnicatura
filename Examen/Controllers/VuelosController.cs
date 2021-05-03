using AeropuertoBAETTI.Models;
using AeropuertoBAETTI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeropuertoBAETTI.Controllers
{
    public class VuelosController : Controller
    {
        // GET: Vuelos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AltaVuelos()
        {
            List<DestinoItemViewModel> listaDestinos = ADVuelos.ADVuelos.ObtenerListaDestinos();

            List<SelectListItem> items = listaDestinos.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idDestino.ToString(),
                    Selected = false

                };

            });
            List<TipoItemViewModel> listaTiposCarga = ADVuelos.ADVuelos.ObtenerListaTipos();

            List<SelectListItem> itemm = listaTiposCarga.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idTipoCarga.ToString(),
                    Selected = false

                };

            });

            ViewBag.items = items;
            ViewBag.itemm = itemm;
            return View();
        }


        [HttpPost]
        public ActionResult AltaVuelos(Vuelo model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = ADVuelos.ADVuelos.InsertarVuelo(model);
                if (resultado == true)
                {
                    ViewBag.Script = "<script type='text/javascript'>alert('El vuelo fue cargado exitosamente');</script>";
                    return RedirectToAction("AltaVuelos", "Vuelos");
                }
                else
                {
                    ViewBag.Script = "<script type='text/javascript'>alert('Debe completar todos los campos');</script>";
                    return View(model);
                }

            }
            else
            {
                ViewBag.Script = "<script type='text/javascript'>alert('Debe completar todos los campos');</script>";
                return View(model);
            }
        }

        public ActionResult ReporteVuelos()
        {
            List<Vuelo> lista = ADVuelos.ADVuelos.ObtenerListaVuelosConsigna();
            return View(lista);
        }
    }
}