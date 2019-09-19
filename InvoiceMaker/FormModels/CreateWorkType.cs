using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.FormModels
{
    public class CreateWorkType
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}