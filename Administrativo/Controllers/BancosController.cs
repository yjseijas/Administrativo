using Administrativo.Services;
using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrativo.Controllers
{
    public class BancosController : Controller
    {
        ApiServices apiservices;
        bool status = false;

        public BancosController()
        {
            this.apiservices = new ApiServices();
        }
        // GET: Bancos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBancos()
        {
            var lista = apiservices.listaBancos(99);

            //var resultado = Json(new { data = lista}, JsonRequestBehavior.AllowGet);

            var resultado = Json(lista.Select(x => new
            {
                idBanco = x.idBanco,
                descripcion = x.descripcion,
                numerocuit = x.numerocuit 
            }), JsonRequestBehavior.AllowGet);


            JsonResult retorno = resultado;
            return retorno;
        }

        public ActionResult GetBanco(int idBanco)
        {
            var lista = apiservices.getBanco(idBanco,99);

            //var resultado = Json(new { data = lista}, JsonRequestBehavior.AllowGet);

            return View(lista);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Bancos());
            }
            else
            {
                var lista = apiservices.getBanco(id, 99);
                var desglose = lista.FirstOrDefault();
                var elbanco = new Bancos();
                elbanco.idBanco = desglose.idBanco;
                elbanco.descripcion = desglose.descripcion;
                elbanco.numerocuit = desglose.numerocuit;
                return View(elbanco);

            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Bancos banco)
        {
            if (banco.idBanco == 0)
            {
                banco.idBanco = 999999;
            }

            //this.Creabanco(banco);
            apiservices.saveBanco(banco,99);
            return Json(new { success = true, message = "Registro se guardó con éxito." }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    this.deleteBanco(id);
        //    return Json(new { success = true, message = "El registro ha sido eliminado." }, JsonRequestBehavior.AllowGet);
        //}
        //private void deleteBanco(int id)
        //{
        //    var resultado =apiservices.deleteBanco(id, 99);
        //    this.status = resultado == "Succes";
        //}

        // GET: Bancos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bancos/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Bancos/Create
        //[HttpPost]
        //public ActionResult Create(Bancos banco)
        //{
        //    try
        //    {
        //        this.Creabanco(banco);
        //        return new JsonResult {Data = new  {status = status } };
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //private async void Creabanco(Bancos banco)
        //{
        //     var resultado =  await apiservices.saveBanco(banco,99);
        //    this.status = resultado == "Succes"; 
        //}

        // GET: Bancos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bancos/Edit/5
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

        // GET: Bancos/Delete/5
        //public ActionResult Delete(Bancos banco)
        //{
        //    try
        //    {
        //        this.Deletebanco(banco.idBanco);
        //        return new JsonResult { Data = new { status = status } };
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //private async void Deletebanco(int id)
        //{
        //    var resultado = await apiservices.deleteBanco(id,99);
        //    this.status = resultado == "Succes";
        //}


// POST: Bancos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                this.deleteBanco(id);
                if (this.status)
                {
                    return Json(new { success = true, message = "El registro ha sido eliminado." }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, message = "El registro no se pudo eliminar." }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
        private void deleteBanco(int id)
        {
            var resultado = apiservices.deleteBanco(id, 99);
            this.status = resultado == "Succes";
        }

    }
}
