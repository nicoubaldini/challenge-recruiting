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
    public class MotoController : Controller
    {
        private readonly IMotoService _motoService;

        public MotoController()
        {
            _motoService = new MotoService(ConfigurationManager.ConnectionStrings["ChallengeRecruitingDB"].ConnectionString);
        }

        // GET: Moto
        public ActionResult Index()
        {
            var lMotos = _motoService.GetAllMotos();

            return View(lMotos);
        }

        // GET: Moto/Details/5
        public ActionResult Details(int id)
        {
            var moto = _motoService.GetMoto(id);
            return View(moto);
        }

        // GET: Moto/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Moto/Create
        [HttpPost]
        public ActionResult Create(Moto motoToInsert)
        {
            try
            {
                _motoService.InsertMoto(motoToInsert);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Moto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Moto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Moto motoToUpdate)
        {
            try
            {
                motoToUpdate.IdMoto = id;
                _motoService.UpdateMoto(motoToUpdate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Moto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Moto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Moto motoToDelete)
        {
            try
            {
                _motoService.DeleteMoto(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
