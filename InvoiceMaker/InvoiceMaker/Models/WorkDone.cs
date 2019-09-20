using System;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        // I'm so sorry, Curtis.
        public int Id { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }

        // Foreign key properties
        public int ClientId { get; set; }
        public int WorkTypeId { get; set; }

        // Navigation properties
        public Client Client { get; set; }
        public WorkType WorkType { get; set; }
        
        public WorkDone() { }

        public WorkDone(int id)
        {
            Id = id;
        }

        public WorkDone(int id, Client client, WorkType workType, DateTimeOffset startedOn, DateTimeOffset? endedOn) : this(client, workType, startedOn, endedOn)
        {
            Id = id;
        }

        public WorkDone(Client client, WorkType workType)
        {
            Client = client;
            WorkType = workType;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(Client client, WorkType workType, DateTimeOffset startedOn) : this(client, workType)
        {
            StartedOn = startedOn;
        }

        public WorkDone(Client client, WorkType workType, DateTimeOffset startedOn, DateTimeOffset? endedOn) : this(client, workType, startedOn)
        {
            EndedOn = endedOn;
        }

        public void Finished()
        {
            if (EndedOn.HasValue)
            {
                EndedOn = DateTimeOffset.Now;
            }
        }

        public decimal? GetTotal()
        {
            if (EndedOn.HasValue)
            {
                return WorkType.Rate * (EndedOn - StartedOn).Value.Hours;
            }
            return null;
        }

        //public void Finished()
        //{
        //    if (EndedOn.HasValue)
        //    {
        //        EndedOn = DateTimeOffset.Now;
        //    }
        //}

        //public decimal? GetTotal()
        //{
        //    if (EndedOn.HasValue)
        //    {
        //        return _type.Rate * (EndedOn - StartedOn).Value.Hours;
        //    }
        //    return null;
        //}
    }
}