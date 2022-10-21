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
    public class AutomovilController : Controller
    {

        private readonly IAutomovilService _automovilService;

        public AutomovilController()
        {
            _automovilService = new AutomovilService(ConfigurationManager.ConnectionStrings["ChallengeRecruitingDB"].ConnectionString);
        }

        // GET: Automovil
        public ActionResult Index()
        {
            var lAutomoviles = _automovilService.GetAllAutomoviles();

            return View(lAutomoviles);
        }

        // GET: Automovil/Details/5
        public ActionResult Details(int id)
        {
            var automovil = _automovilService.GetAutomovil(id);

            return View(automovil);
        }

        // GET: Automovil/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Automovil/Create
        [HttpPost]
        public ActionResult Create(Automovil automovilToInsert)
        {
            try
            {
                _automovilService.InsertAutomovil(automovilToInsert);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Automovil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Automovil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Automovil automovilToUpdate)
        {
            try
            {
                automovilToUpdate.IdAutomovil = id;
                _automovilService.UpdateAutomovil(automovilToUpdate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Automovil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Automovil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Automovil automovilToDelete)
        {
            try
            {
                _automovilService.DeleteAutomovil(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
