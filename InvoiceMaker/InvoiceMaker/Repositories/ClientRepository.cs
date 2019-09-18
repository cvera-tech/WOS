using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        private Context _context;

        public ClientRepository() { }

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public List<Client> GetClients()
        {
            var clients = _context.Clients
                .OrderBy(c => c.Name)
                .ToList();
            return clients;
        }

        public void Insert(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client GetById(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);
            return client;
        }

        public void Update(Client client)
        {
            // SaveChanges is called by the extension method
            _context.UpdateEntity<Client>(client);
        }
    }
}