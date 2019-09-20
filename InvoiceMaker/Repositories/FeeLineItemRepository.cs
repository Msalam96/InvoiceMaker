using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class FeeLineItemRepository
    {
        private Context _context;

        public FeeLineItemRepository(Context context)
        {
            _context = context;
        }

        public void Insert(FeeLineItem feeLineItem)
        {
            _context.FeeLineItems.Add(feeLineItem);
            _context.SaveChanges();
        }

    }
}