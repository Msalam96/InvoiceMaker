﻿using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InvoiceMaker.Repositories
{
    public class InvoiceRepository
    {
        private Context _context;

        public InvoiceRepository(Context context)
        {
            _context = context;
        }

        public List<Invoice> GetInvoices()
        {
            return _context.Invoices
                .Include(c => c.Client)
                .ToList();
        }

        public Invoice GetInvoice(int id)
        {
            return _context.Invoices
                .Include(c => c.Client)
                .SingleOrDefault(i => i.Id == id);
        }

        public void Insert(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }
    }
}