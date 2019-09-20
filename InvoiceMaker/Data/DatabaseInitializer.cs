using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            Client client = new Client(0, "Mohammed Salam", true);

            context.Clients.Add(client);
           
            var invoice = new Invoice(0, "100", client);
            //invoice.Client = client;
            context.Invoices.Add(invoice);

            context.SaveChanges();
        }
    }
}