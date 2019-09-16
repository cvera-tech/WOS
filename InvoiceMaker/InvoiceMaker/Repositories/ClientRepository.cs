using InvoiceMaker.Models;
using System.Collections.Generic;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        public List<Client> GetClients()
        {
            string sql = @"
                SELECT Id, ClientName, IsActivated
                FROM Client
                ORDER BY ClientName
            ";

            List<Client> clients = DatabaseHelper.Retrieve<Client>(sql);
            return clients;
        }
    }
}