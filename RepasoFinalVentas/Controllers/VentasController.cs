using RepasoFinalVentas.AccesoDatos;
using RepasoFinalVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepasoFinalVentas.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AltaVenta()
        {
            List<ViewModels.FPItemViewModel> listaFormaPago = AD_Ventas.ObtenerListaFormaPago();

            List<SelectListItem> items = listaFormaPago.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };

            });
            ViewBag.items = items;
            List<ViewModels.PLItemViewModel> listaPlanCuotas = AD_Ventas.ObtenerPlanCuotas();

            List<SelectListItem> itemm = listaPlanCuotas.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.cantidadCuotas.ToString(),
                    Value = d.id.ToString(),
                    Selected = false

                };

            });

            
            ViewBag.itemm = itemm;
            return View();
        }

        [HttpPost]

        public ActionResult AltaVenta(Ventas model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Ventas.InsertarVenta(model);
                if (resultado == true)
                {
                    //ACA PONER OTRA VISTA
                    return RedirectToAction("AltaVenta", "Ventas");
                }
                else
                {
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }

        }
    }

}