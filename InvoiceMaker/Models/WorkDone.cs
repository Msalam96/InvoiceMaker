using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        public WorkDone() { }

        public WorkDone(int id, Client client, WorkType worktype)
        {
            Id = id;
            Client = client;
            ClientId = client.Id;
            WorkType = worktype;
            WorkTypeId = worktype.Id;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startDate)
        {
            Id = id;
            Client = client;
            ClientId = client.Id;
            WorkType = worktype;
            WorkTypeId = worktype.Id;
            StartedOn = startDate;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            Id = id;
            Client = client;
            ClientId = client.Id;
            WorkType = worktype;
            WorkTypeId = worktype.Id;
            StartedOn = startDate;
            EndedOn = endDate;
        }

        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }

        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }

        //public int InvoiceId { get; set; }
        //public Invoice Invoice { get; set; }

        //public string WorkTypeName { get { return workType.Name; } }
        //public int WorkTypeId { get { return workType.Id; } }
        //public decimal WorkTypeRate { get { return workType.Rate; } }

        public void Finished()
        {
            if(EndedOn == null)
            {
                EndedOn = DateTimeOffset.Now;
            }
        }
        
        public decimal GetTotal()
        {
            if(EndedOn != null)
            {
                var elaspedTime = (decimal)(EndedOn.Value - StartedOn).TotalHours;
                return WorkType.Rate * elaspedTime;
            }
            return 0;
        }

        
        //private Client client;
        //private WorkType workType;
    }
}