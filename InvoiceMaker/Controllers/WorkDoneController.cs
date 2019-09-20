using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorkDoneController : Controller
    {
        public Context context;

        public WorkDoneController()
        {
            context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
        }
        // GET: WorkDone
        public ActionResult Index()
        {
            var repo = new WorkDoneRepository(context);
            IList<WorkDone> workDones = repo.GetWorkDones();
            return View("Index", workDones);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateWorkDoneView model = new CreateWorkDoneView();
            model.Clients = new ClientRepository(context).GetClients();
            model.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(CreatInvoice model)
        {
            try
            {
                // Get the client and work type based on values submitted from
                // the form
                Client client = new ClientRepository(context).GetById(model.ClientId);
                WorkType workType = new WorkTypeRepository(context).GetById(model.WorkTypeId);

                // Create an instance of the work done with the client and work
                // type
                WorkDone workDone = new WorkDone(0, client, workType);
                new WorkDoneRepository(context).Insert(workDone);
                return RedirectToAction("Index");
            }
            catch { }

            // Create a view model
            CreateWorkDoneView viewModel = new CreateWorkDoneView();

            // Copy over the values from the values submitted
            viewModel.ClientId = model.ClientId;
            viewModel.StartedOn = model.StartedOn;
            viewModel.WorkTypeId = model.WorkTypeId;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository().GetClients();
            viewModel.WorkTypes = new WorkTypeRepository().GetWorkTypes();
            return View("Create", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            WorkDoneRepository repo = new WorkDoneRepository(context);
            WorkDone workDone = repo.GetById(id);

            EditWorkDoneView model = new EditWorkDoneView();
            model.Id = workDone.Id;
            model.ClientId = workDone.ClientId;
            model.WorkTypeId = workDone.WorkTypeId;
            model.StartedOn = workDone.StartedOn;

            model.Clients = new ClientRepository(context).GetClients();
            model.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditWorkDone workDone)
        {
            WorkDoneRepository repo = new WorkDoneRepository(context);

            //try
            //{
            //    // Get the client and work type based on values submitted from
            //    // the form
            //    Client client = new ClientRepository().GetById(model.ClientId);
            //    WorkType workType = new WorkTypeRepository().GetById(model.WorkTypeId);

            //    // Create an instance of the work done with the client and work
            //    // type
            //    WorkDone workDone = new WorkDone(0, client, workType);
            //    new WorkDoneRepository().Insert(workDone);
            //    return RedirectToAction("Index");
            try
            {
                Client client = new ClientRepository(context).GetById(workDone.ClientId);
                WorkType workType = new WorkTypeRepository(context).GetById(workDone.WorkTypeId);
                WorkDone newworkDone = new WorkDone(id, client, workType, workDone.StartedOn);
                repo.Update(newworkDone);

                return RedirectToAction("Index");
            }
            catch { }
            
            CreateWorkDoneView viewModel = new CreateWorkDoneView();

            // Copy over the values from the values submitted
            viewModel.ClientId = workDone.ClientId;
            viewModel.StartedOn = workDone.StartedOn;
            viewModel.WorkTypeId = workDone.WorkTypeId;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository(context).GetClients();
            viewModel.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Edit", workDone);
        }


        public ActionResult Finish(int id)
        {
            var repo = new WorkDoneRepository(context);
            var workDone = repo.GetById(id);
            workDone.Finished();
            try
            {
                //Client client = new ClientRepository(context).GetById(workDone.ClientId);
                //WorkType workType = new WorkTypeRepository(context).GetById(workDone.WorkTypeId);
                //WorkDone newworkDone = new WorkDone(id, client, workType, workDone.StartedOn, endDate);
                repo.Update(workDone);

                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {

            }


            return RedirectToAction("Index");
        }
    }
}