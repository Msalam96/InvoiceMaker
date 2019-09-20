using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        public Invoice()
        {
            FeeLineItems = new List<FeeLineItem>();
        }

        public Invoice(int id, string invoiceNumber, Client client) : this()
        {
            Id = id;
            InvoiceNumber = invoiceNumber;
            //LineItems = new List<ILineItem>();
            Status = InvoiceStatus.Open;
            Client = client;
        }

        public Invoice(int id, string invoiceNumber, Client client, InvoiceStatus status)
            : this(id, invoiceNumber, client)
        {
            Status = status;
        }

        public void FinalizeInvoice()
        {
            if (Status == InvoiceStatus.Open)
            {
                Status = InvoiceStatus.Finalized;
            }
        }

        public void CloseInvoice()
        {
            if (Status == InvoiceStatus.Finalized)
            {
                Status = InvoiceStatus.Closed;
            }
        }

        //public void AddWorkLineItem(WorkDone workDone)
        //{
        //    LineItems.Add(new WorkLineItem(workDone));
        //}

        //public void AddFeeLineItem(decimal amount, string description, DateTimeOffset when)
        //{
        //    LineItems.Add(new FeeLineItem(amount, description, when));
        //}

        public int Id { get; set; }
        public InvoiceStatus Status { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        //public List<ILineItem> LineItems { get; private set; }

        public List<FeeLineItem> FeeLineItems { get; set; }
    }
}