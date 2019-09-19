using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class WorkTypeRepository
    {
        private Context _context;
        private string _connectionString;

        public WorkTypeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceDatabase"].ConnectionString;
        }

        public WorkTypeRepository(Context context)
        {
            _context = context;
        }
        public List<WorkType> GetWorkTypes()
        {
            return _context.WorkTypes.ToList();
        }

        public WorkType GetById(int id)
        {
            return _context.WorkTypes.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(WorkType workType)
        {
            _context.WorkTypes.Add(workType);
            _context.SaveChanges();
        }

        public void Update(WorkType workType)
        {
            _context.WorkTypes.Attach(workType);
            _context.Entry(workType).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}