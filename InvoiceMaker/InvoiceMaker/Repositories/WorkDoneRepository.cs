using InvoiceMaker.Models;
using System.Data.SqlClient;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        public WorkDone GetById(int id)
        {
            string sql = @"
                SELECT WD.Id, WD.ClientId, WD.WorkTypeId, WD.StartedOn,
                    WD.EndedOn, C.ClientName, C.IsActivated,
                    WT.Name AS WorkTypeName, WT.Rate
                FROM WorkDone WD
                    JOIN Client C ON WD.ClientId = C.Id
                    JOIN WorkType WT ON WD.WorkTypeId = WT.Id
                WHERE Id = @Id
            ";
            var workDoneRaw = DatabaseHelper.RetrieveSingle<WorkDoneRaw>(sql, 
                new SqlParameter("@Id", id));
            var client = new Client(workDoneRaw.ClientId, workDoneRaw.ClientName, workDoneRaw.IsActivated);
            var workType = new WorkType(workDoneRaw.WorkTypeId, workDoneRaw.WorkTypeName, workDoneRaw.Rate);
            var workDone = new WorkDone(client, workType, workDoneRaw.StartedOn, workDoneRaw.EndedOn);
            return workDone;
        }
    }
}