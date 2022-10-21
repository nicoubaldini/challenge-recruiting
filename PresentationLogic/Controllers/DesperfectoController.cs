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
    public class DesperfectoController : Controller
    {
        private readonly IDesperfectoService _desperfectoService;

        public DesperfectoController()
        {
            _desperfectoService = new DesperfectoService(ConfigurationManager.ConnectionStrings["ChallengeRecruitingDB"].ConnectionString);
        }
        // GET: Desperfecto
        public ActionResult Index()
        {
            var lDesperfectos = _desperfectoService.GetAllDesperfectos();

            return View(lDesperfectos);
        }

        // GET: Repuesto/Details/5
        public ActionResult Details(int id)
        {
            Desperfecto desperfecto = null;
            try
            {
                desperfecto = _desperfectoService.GetDesperfecto(id);
            }
            catch (Exception ex) { }

            return View(desperfecto);
        }

        public ActionResult Vehiculos(int id)
        {
            var lDesperfectos = _desperfectoService.GetDesperfectosFromVehiculo(id);

            return View(lDesperfectos);
        }

        public ActionResult Repuestos(int id)
        {
            var lDesperfectos = _desperfectoService.GetDesperfectosFromRepuesto(id);

            return View(lDesperfectos);
        }

        // GET: Desperfecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desperfecto/Create
        [HttpPost]
        public ActionResult Create(Desperfecto desperfectoToInsert)
        {
            try
            {
                _desperfectoService.InsertDesperfecto(desperfectoToInsert);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Desperfecto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Desperfecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Desperfecto desperfectoToUpdate)
        {
            try
            {
                desperfectoToUpdate.IdDesperfecto = id;
                _desperfectoService.UpdateDesperfecto(desperfectoToUpdate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Desperfecto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Desperfecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Desperfecto desperfectoToDelete)
        {
            try
            {
                _desperfectoService.DeleteDesperfecto(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
