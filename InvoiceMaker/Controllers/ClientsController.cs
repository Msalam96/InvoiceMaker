using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class ClientsController : Controller
    {
        private Context context;

        public ClientsController()
        {
            context = new Context();
        }
        // GET: Clients
        [HttpGet]
        public ActionResult Index()
        {
            var repository = new ClientRepository(context);
            IList<Client> clients = repository.GetClients();
            //ClientRepository repo = new ClientRepository();
            //List<Client> clients = repo.GetClients();
            return View("Index", clients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateClient client = new CreateClient();
            client.IsActivated = true;
            return View("Create", client);

        }

        [HttpPost]
        public ActionResult Create(CreateClient client)
        {
            ClientRepository repo = new ClientRepository(context);
            try
            {
                Client newClient = new Client(0, client.Name, client.IsActivated);
                repo.Insert(newClient);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException exception)
            {
                HandleDbException(exception);
            }
            return View("Create", client);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClientRepository repo = new ClientRepository(context);
            Client client = repo.GetById(id);

            EditClient model = new EditClient();
            model.Id = client.Id;
            model.IsActivated = client.IsActive;
            model.Name = client.Name;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditClient client)
        {
            ClientRepository repo = new ClientRepository(context);
            try
            {
                Client newClient = new Client(id, client.Name, client.IsActivated);
                repo.Update(newClient);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException exception)
            {
                HandleDbException(exception);
            }
            return View("Edit", client);
        }


        private void HandleDbException(DbUpdateException exception)
        {
            SqlException sqlException = exception.InnerException.InnerException as SqlException;
            if (sqlException != null && sqlException.Number == 2627)
            {
                ModelState.AddModelError("Name", "That is already taken.");
            }
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