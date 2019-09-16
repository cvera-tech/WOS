using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InvoiceMaker.Repositories
{
    public class WorkTypeRepository
    {
        public List<WorkType> GetWorkTypes()
        {
            string sql = @"
                SELECT Id, Name, Rate
                FROM WorkType
            ";
            List<WorkType> workTypes = DatabaseHelper.Retrieve<WorkType>(sql);
            return workTypes;
        }

        public void Insert(WorkType workType)
        {
            string sql = @"
                INSERT INTO WorkType (Name, Rate)
                VALUES (@Name, @Rate)
            ";

            DatabaseHelper.Execute(sql,
                new SqlParameter("@Name", workType.Name),
                new SqlParameter("@Rate", workType.Rate));
        }
    }
}