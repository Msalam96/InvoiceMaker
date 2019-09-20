using InvoiceMaker.Data;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}