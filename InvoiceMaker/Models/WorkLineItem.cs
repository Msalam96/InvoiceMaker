using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        public WorkLineItem(WorkDone workDone)
        {
            Amount = workDone.GetTotal();
            Description = workDone.WorkType.Name;
            When = workDone.StartedOn;
        }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset When { get; private set; }
    }
}