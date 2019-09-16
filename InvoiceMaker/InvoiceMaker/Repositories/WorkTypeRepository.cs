using InvoiceMaker.Models;
using System.Collections.Generic;

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
    }
}