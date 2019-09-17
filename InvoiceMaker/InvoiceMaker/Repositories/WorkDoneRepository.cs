using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        // Grammar is important.
        public List<WorkDone> GetWorksDone()
        {
            string sql = @"
                SELECT WD.Id, WD.ClientId, WD.WorkTypeId, WD.StartedOn,
                    WD.EndedOn, C.ClientName, C.IsActivated,
                    WT.Name AS WorkTypeName, WT.Rate
                FROM WorkDone WD
                    JOIN Client C ON WD.ClientId = C.Id
                    JOIN WorkType WT ON WD.WorkTypeId = WT.Id
                ORDER BY WorkTypeName
            ";
            List<WorkDoneDTO> workDoneDTOs = DatabaseHelper.Retrieve<WorkDoneDTO>(sql);
            List<WorkDone> worksDone = new List<WorkDone>();

            foreach(var dto in workDoneDTOs)
            {
                var client = new Client(dto.ClientId, dto.ClientName, dto.IsActivated);
                var workType = new WorkType(dto.WorkTypeId, dto.WorkTypeName, dto.Rate);
                var workDone = new WorkDone(dto.Id, client, workType, dto.StartedOn, dto.EndedOn);
                worksDone.Add(workDone);
            }

            return worksDone;
        }

        public WorkDone GetById(int id)
        {
            string sql = @"
                SELECT WD.Id, WD.ClientId, WD.WorkTypeId, WD.StartedOn,
                    WD.EndedOn, C.ClientName, C.IsActivated,
                    WT.Name AS WorkTypeName, WT.Rate
                FROM WorkDone WD
                    JOIN Client C ON WD.ClientId = C.Id
                    JOIN WorkType WT ON WD.WorkTypeId = WT.Id
                WHERE WD.Id = @Id
            ";
            var workDoneDTO = DatabaseHelper.RetrieveSingle<WorkDoneDTO>(sql, 
                new SqlParameter("@Id", id));
            var client = new Client(workDoneDTO.ClientId, workDoneDTO.ClientName, workDoneDTO.IsActivated);
            var workType = new WorkType(workDoneDTO.WorkTypeId, workDoneDTO.WorkTypeName, workDoneDTO.Rate);
            var workDone = new WorkDone(client, workType, workDoneDTO.StartedOn, workDoneDTO.EndedOn);
            return workDone;
        }

        public void Insert (WorkDone workDone)
        {
            string sql = @"
                INSERT INTO WorkDone (ClientId, WorkTypeId, StartedOn, EndedOn)
                VALUES (@ClientId, @WorkTypeId, @StartedOn, @EndedOn)
            ";
            
            DatabaseHelper.Insert(sql,
                new SqlParameter("@ClientId", workDone.ClientId),
                new SqlParameter("@WorkTypeId", workDone.WorkTypeId),
                new SqlParameter("@StartedOn", workDone.StartedOn),
                new SqlParameter("@EndedOn", workDone.EndedOn ?? (object)DBNull.Value));
        }

        public void Update (WorkDone workDone)
        {
            string sql = @"
                UPDATE 
                    WorkDone
                SET 
                    ClientId = @ClientId,
                    WorkTypeId = @WorkTypeId,
                    StartedOn = @StartedOn,
                    EndedOn = @EndedOn
                WHERE 
                    Id = @Id
            ";
            DatabaseHelper.Update(sql,
                new SqlParameter("@ClientId", workDone.ClientId),
                new SqlParameter("@WorkTypeId", workDone.WorkTypeId),
                new SqlParameter("@StartedOn", workDone.StartedOn),
                new SqlParameter("@EndedOn", workDone.EndedOn ?? (object)DBNull.Value),
                new SqlParameter("@Id", workDone.Id));
        }
    }
}