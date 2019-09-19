using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        private Context _context;
        private string _connectionString;

        public ClientRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceDatabase"].ConnectionString;
        }

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            _context.Clients.Attach(client);
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}