using PresentationLogic.Models;
using PresentationLogic.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLogic.Controllers
{
    public class RepuestoController : Controller
    {
        private readonly IRepuestoService _repuestoService;

        public RepuestoController()
        {
            _repuestoService = new RepuestoService(ConfigurationManager.ConnectionStrings["ChallengeRecruitingDB"].ConnectionString);
        }

        // GET: Repuesto
        public ActionResult Index()
        {
            var lRepuestos = _repuestoService.GetAllRepuestos();

            return View(lRepuestos);
        }

        public ActionResult Desperfecto(int id)
        {
            var lRepuestos = _repuestoService.GetRepuestosFromDesperfecto(id);

            return View(lRepuestos);
        }

        // GET: Repuesto/Details/5
        public ActionResult Details(int id)
        {
            var repuesto = _repuestoService.GetRepuesto(id);

            return View(repuesto);
        }

        // GET: Repuesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repuesto/Create
        [HttpPost]
        public ActionResult Create(Repuesto repuestoToInsert)
        {
            try
            {
                _repuestoService.InsertRepuesto(repuestoToInsert);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repuesto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Repuesto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Repuesto repuestoToUpdate)
        {
            try
            {
                repuestoToUpdate.IdRepuesto = id;
                _repuestoService.UpdateRepuesto(repuestoToUpdate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repuesto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repuesto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Repuesto repuestoToDelete)
        {
            try
            {
                _repuestoService.DeleteRepuesto(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
