using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class FeeLineItemController : Controller
    {
        private Context context;

        public FeeLineItemController()
        {
            context = new Context();
        }
        // GET: FeeLineItems
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            CreateFeeLineItem feeLineItem = new CreateFeeLineItem();
            return View("Create", feeLineItem);

        }

        [HttpPost]
        public ActionResult Create(int id, CreateFeeLineItem feeLineItem)
        {
            FeeLineItemRepository repo = new FeeLineItemRepository(context);
            try
            {
                DateTimeOffset when = DateTimeOffset.Now;
                FeeLineItem newFeeLineItem = new FeeLineItem(0, feeLineItem.Amount, feeLineItem.Description, when);
                newFeeLineItem.InvoiceId = id;
                InvoiceRepository invRepo = new InvoiceRepository(context);
                var invoice = invRepo.GetInvoice(id);
                invoice.FeeLineItems.Add(newFeeLineItem);
                repo.Insert(newFeeLineItem);
                return RedirectToRoute("Default", new { controller = "Invoices", action = "Edit", id = id });
            }
            catch (DbUpdateException exception)
            {
               
            }
            return View("Create", feeLineItem);
        }
    }
}