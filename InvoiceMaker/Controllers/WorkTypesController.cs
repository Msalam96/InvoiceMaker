using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorkTypesController : Controller
    {
        private Context context;

        public WorkTypesController()
        {
            context = new Context();
        }

        // GET: WorkTypes
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new WorkTypeRepository(context);
            IList<WorkType> workType = repo.GetWorkTypes();
            return View("Index", workType);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateWorkType workType = new CreateWorkType();
            return View("Create", workType);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkType workType)
        {
            WorkTypeRepository repo = new WorkTypeRepository(context);
            try
            {
                WorkType newWorkType = new WorkType(0, workType.Name, workType.Rate);
                repo.Insert(newWorkType);
                return RedirectToAction("Index");
            } catch
            {

            }
            //catch (SqlException se)
            //{
            //    if (se.Number == 2627)
            //    {
            //        ModelState.AddModelError("Name", "That name is already taken.");
            //    }
            //}
            return View("Create", workType);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            WorkTypeRepository repo = new WorkTypeRepository(context);
            WorkType workType = repo.GetById(id);
        
            EditWorkType model = new EditWorkType();
            model.Id = workType.Id;
            model.Rate = workType.Rate;
            model.Name = workType.Name;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditWorkType workType)
        {
            WorkTypeRepository repo = new WorkTypeRepository(context);
            try
            {
                WorkType newWorkType = new WorkType(id, workType.Name, workType.Rate);
                repo.Update(newWorkType);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken.");
                }
            }
            return View("Edit", workType);
        }

        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                context.Dispose();
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }
}