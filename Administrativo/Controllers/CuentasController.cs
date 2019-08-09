using Administrativo.Services;
using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrativo.Controllers
{
    public class CuentasController : Controller
    {
        ApiServices apiServices;

        public CuentasController()
        {
            this.apiServices = new ApiServices();
        }
        // GET: Cuentas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCuentas()
        {
            var lista = this.apiServices.listaCuentas(99);

            //var resultado = Json(new { data = lista}, JsonRequestBehavior.AllowGet);

            var resultado = Json(lista.Select(x => new
            {
                idCuenta = x.idCuenta,
                descripcion = x.descripcion,
                recibeasientos = x.recibeasientos,
                ajustable = x.ajustable,
                desTipo = x.desTipo

            }), JsonRequestBehavior.AllowGet);

            JsonResult retorno = resultado;
            return retorno;
        }

        public ActionResult GetCuenta(int idCuenta)
        {
            var lista = this.apiServices.getCuenta(idCuenta, 99);

            //var resultado = Json(new { data = lista}, JsonRequestBehavior.AllowGet);

            return View(lista);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var lacuenta = new Cuentas();
                lacuenta.idTipoCuenta = 0;
                var tiposcuentas = apiServices.listaTiposCuentas(99);
                ViewBag.idTipoCuenta = new SelectList(tiposcuentas.OrderBy(t => t.descripcion), "idTipoCuenta", "descripcion", lacuenta.idTipoCuenta);
                return View(new Cuentas());
            }
            else
            {
                var lista = this.apiServices.getCuenta(id, 99);
                var desglose = lista.FirstOrDefault();
                var lacuenta = new Cuentas();
                lacuenta.idCuenta = desglose.idCuenta;
                lacuenta.descripcion = desglose.descripcion;
                lacuenta.idTipoCuenta = desglose.idTipoCuenta;
                lacuenta.recibeasientos = desglose.recibeasientos;
                lacuenta.ajustable = desglose.ajustable;
                var tiposcuentas = apiServices.listaTiposCuentas(99);
                //var tipocuenta = tiposcuentas.FirstOrDefault(a => a.idTipoCuenta == lacuenta.idTipoCuenta);

                ViewBag.idTipoCuenta = new SelectList(tiposcuentas.OrderBy(t => t.descripcion), "idTipoCuenta", "descripcion", lacuenta.idTipoCuenta);
                return View(lacuenta);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Cuentas cuenta)
        {
            this.apiServices.saveCuenta(cuenta, 99);
            return Json(new { success = true, message = "Registro se guardó con éxito." }, JsonRequestBehavior.AllowGet);
        }


        // GET: Cuentas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuentas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuentas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuentas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
