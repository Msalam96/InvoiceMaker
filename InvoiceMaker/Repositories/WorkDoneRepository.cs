using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        private Context _context;
       
        public WorkDoneRepository(Context context)
        {
            _context = context;
        }

        public List<WorkDone> GetWorkDones()
        {
            return _context.WorkDones
                .Include(c => c.Client)
                .Include(wt => wt.WorkType)
                .OrderBy(c => c.Client.Name)
                .ToList();
        }

        public WorkDone GetById(int id)
        {
            return _context.WorkDones
                .Include(c => c.Client)
                .Include(wt => wt.WorkType)
                .SingleOrDefault(wd => wd.Id == id);
        }

        public void Insert(WorkDone workDone)
        {
            _context.WorkDones.Add(workDone);
            _context.SaveChanges();
        }

        public void Update(WorkDone workDone)
        {
            //_context.WorkDones.Attach(workDone);
            _context.Entry(workDone).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}