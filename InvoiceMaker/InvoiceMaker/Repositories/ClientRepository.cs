using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        public List<Client> GetClients()
        {
            string sql = @"
                SELECT Id, ClientName AS Name, IsActivated AS IsActive
                FROM Client
                ORDER BY ClientName
            ";

            List<Client> clients = DatabaseHelper.Retrieve<Client>(sql);
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
    }
}