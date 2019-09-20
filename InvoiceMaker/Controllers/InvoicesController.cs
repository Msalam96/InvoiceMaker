using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class InvoicesController : Controller
    {
        private Context context;

        public InvoicesController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var repository = new InvoiceRepository(context);
            IList<Invoice> invoices = repository.GetInvoices();
            //ClientRepository repo = new ClientRepository();
            //List<Client> clients = repo.GetClients();
            return View("Index", invoices);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateInvoiceView model = new CreateInvoiceView();
            model.Clients = new ClientRepository(context).GetClients();
            //model.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(CreateInvoice model)
        {
            try
            {
                // Get the client and work type based on values submitted from
                // the form
                Client client = new ClientRepository(context).GetById(model.ClientId);

                // Create an instance of the work done with the client and work
                // type
                Invoice invoice = new Invoice(0, model.InvoiceNumber, client);
                new InvoiceRepository(context).Insert(invoice);
                return RedirectToAction("Index");
            }
            catch(Exception exception){}

            // Create a view model
            CreateInvoiceView viewModel = new CreateInvoiceView();

            // Copy over the values from the values submitted
            viewModel.ClientId = model.ClientId;
            viewModel.InvoiceNumber = model.InvoiceNumber;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository(context).GetClients();
            return View("Create", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var repo = new InvoiceRepository(context);
            Invoice invoice = repo.GetInvoice(id);

            return View("Edit", invoice);
        }
    }
}