using InvoiceMaker.Data;
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
            //string sql = @"
            //    SELECT Id, Name, Rate
            //    FROM WorkType
            //    ORDER BY Name
            //";
            //List<WorkType> workTypes = DatabaseHelper.Retrieve<WorkType>(sql);
            //return workTypes;
            var workTypes = _context.WorkTypes
                .OrderBy(wt => wt.Name)
                .ToList();
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

        public WorkType GetById(int Id)
        {
            string sql = @"
                SELECT Id, Name, Rate
                FROM WorkType
                WHERE Id = @Id
            ";

            WorkType workType = DatabaseHelper.RetrieveSingle<WorkType>(sql,
                new SqlParameter("@Id", Id));

            return workType;
        }

        public void Update(WorkType workType)
        {
            string sql = @"
                UPDATE WorkType
                SET Name = @Name,
                    Rate = @Rate
                WHERE Id = @Id
            ";

            DatabaseHelper.Execute(sql,
                new SqlParameter("@Name", workType.Name),
                new SqlParameter("@Rate", workType.Rate),
                new SqlParameter("@Id", workType.Id));
        }
    }
}