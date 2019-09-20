using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository : BaseRepository
    {
        public ClientRepository(Context context) : base(context) { }

        public List<Client> GetClients()
        {
            var clients = _context.Clients
                .OrderByDescending(c => c.IsActive)
                .ThenBy(c => c.Name)
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

        public List<SelectListItem> GetSelectListItems()
        {
            var clients = GetClients();
            var selectListItems = new List<SelectListItem>();
            clients.ForEach(c =>
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            });
            return selectListItems;
        }
    }
}