﻿using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class WorkTypeRepository : BaseRepository
    {
        public WorkTypeRepository() : base(null) { }

        public WorkTypeRepository(Context context) : base(context) { }

        public List<WorkType> GetWorkTypes()
        {
            var workTypes = _context.WorkTypes
                .OrderBy(wt => wt.Name)
                .ToList();
            return workTypes;
        }

        public void Insert(WorkType workType)
        {
            _context.WorkTypes.Add(workType);
            _context.SaveChanges();
        }

        public WorkType GetById(int id)
        {
            var workType = _context.WorkTypes
                .SingleOrDefault(wt => wt.Id == id);
            return workType;
        }

        public void Update(WorkType workType)
        {
            // SaveChanges is called by the extension method
            _context.UpdateEntity<WorkType>(workType);
        }
    }
}