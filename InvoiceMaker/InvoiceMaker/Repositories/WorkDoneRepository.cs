using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository : BaseRepository
    {
        public WorkDoneRepository() : base(null) { }

        public WorkDoneRepository(Context context) : base(context) { }

        // Grammar is important.
        public List<WorkDone> GetWorksDone()
        {
            //string sql = @"
            //    SELECT WD.Id, WD.ClientId, WD.WorkTypeId, WD.StartedOn,
            //        WD.EndedOn, C.ClientName, C.IsActivated,
            //        WT.Name AS WorkTypeName, WT.Rate
            //    FROM WorkDone WD
            //        JOIN Client C ON WD.ClientId = C.Id
            //        JOIN WorkType WT ON WD.WorkTypeId = WT.Id
            //    ORDER BY WorkTypeName
            //";
            //List<WorkDoneDTO> workDoneDTOs = DatabaseHelper.Retrieve<WorkDoneDTO>(sql);
            //List<WorkDone> worksDone = new List<WorkDone>();

            //foreach(var dto in workDoneDTOs)
            //{
            //    var client = new Client(dto.ClientId, dto.ClientName, dto.IsActivated);
            //    var workType = new WorkType(dto.WorkTypeId, dto.WorkTypeName, dto.Rate);
            //    var workDone = new WorkDone(dto.Id, client, workType, dto.StartedOn, dto.EndedOn);
            //    worksDone.Add(workDone);
            //}

            //return worksDone;
            //_context.Database.Log = m => Debug.WriteLine(m);
            var worksDone = _context.WorksDone
                .Include(wd => wd.Client)
                .Include(wd => wd.WorkType)
                .ToList();

            return worksDone;
        }

        public WorkDone GetById(int id)
        {
            //string sql = @"
            //    SELECT WD.Id, WD.ClientId, WD.WorkTypeId, WD.StartedOn,
            //        WD.EndedOn, C.ClientName, C.IsActivated,
            //        WT.Name AS WorkTypeName, WT.Rate
            //    FROM WorkDone WD
            //        JOIN Client C ON WD.ClientId = C.Id
            //        JOIN WorkType WT ON WD.WorkTypeId = WT.Id
            //    WHERE WD.Id = @Id
            //";
            //var workDoneDTO = DatabaseHelper.RetrieveSingle<WorkDoneDTO>(sql, 
            //    new SqlParameter("@Id", id));
            //var client = new Client(workDoneDTO.ClientId, workDoneDTO.ClientName, workDoneDTO.IsActivated);
            //var workType = new WorkType(workDoneDTO.WorkTypeId, workDoneDTO.WorkTypeName, workDoneDTO.Rate);
            //var workDone = new WorkDone(client, workType, workDoneDTO.StartedOn, workDoneDTO.EndedOn);
            //return workDone;
            var workDone = _context.WorksDone
                .Include(wd => wd.Client)
                .Include(wd => wd.WorkType)
                .SingleOrDefault(wd => wd.Id == id);

            return workDone;
        }

        public void Insert(WorkDone workDone)
        {
            _context.WorksDone.Add(workDone);

            if (workDone.Client != null && workDone.Client.Id > 0)
            {
                _context.Entry(workDone.Client).State = EntityState.Unchanged;
            }
            if (workDone.WorkType != null && workDone.WorkType.Id > 0)
            {
                _context.Entry(workDone.WorkType).State = EntityState.Unchanged;
            }
            _context.SaveChanges();
        }

        public void Update(WorkDone workDone)
        {
            // SaveChanges is called by the extension method
            _context.UpdateEntity(workDone);
        }
    }
}