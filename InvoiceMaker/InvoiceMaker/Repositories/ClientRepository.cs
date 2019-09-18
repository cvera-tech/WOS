using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var clients = _context.Clients.ToList();
            return clients;
        }

        public void Insert(Client client)
        {
            string sql = @"
                INSERT INTO Client(ClientName, IsActivated)
                VALUES (@ClientName, @IsActivated)
            ";

            DatabaseHelper.Execute(sql,
                new SqlParameter("@ClientName", client.Name),
                new SqlParameter("@IsActivated", client.IsActive));
        }

        public Client GetById(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);
            return client;
        }

        public void Update(Client client)
        {
            //int id = client.Id;
            //string name = client.Name;
            //bool isActive = client.IsActive;
            //_context.UpdateById<Client>(client.Id, "Name", name, "IsActive", isActive);

            _context.UpdateEntity<Client>(client);
        }
    }
}