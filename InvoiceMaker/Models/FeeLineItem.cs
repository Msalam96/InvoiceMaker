using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class FeeLineItem : ILineItem
    {
        public FeeLineItem(decimal amount, string description, DateTimeOffset when)
        {
            Amount = amount;
            Description = description;
            When = when;
        }

        public int Id { get; set; }
        public decimal Amount { get; private set; }
        public string Description { get; set; }
        public DateTimeOffset When { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}