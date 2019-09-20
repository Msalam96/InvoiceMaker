using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.FormModels
{
    public class CreateFeeLineItem
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTimeOffset When { get; set; }
    }
}