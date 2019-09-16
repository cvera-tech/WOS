using System;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        private Client _client;
        private WorkType _type;

        public string ClientName
        {
            get
            {
                return _client.Name;
            }
        }
        public DateTimeOffset EndedOn { get; private set; }
        public DateTimeOffset StartedOn { get; private set; }
        public string WorkTypeName
        {
            get
            {
                return _type.Name;
            }
        }

        public WorkDone(Client client, WorkType workType)
        {
            _client = client;
            _type = workType;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(Client client, WorkType workType, DateTimeOffset startedOn) : this(client, workType)
        {
            StartedOn = startedOn;
        }

        public WorkDone(Client client, WorkType workType, DateTimeOffset startedOn, DateTimeOffset endedOn) : this(client, workType, startedOn)
        {
            EndedOn = endedOn;
        }

        public void Finished()
        {
            if (EndedOn == null)
            {
                EndedOn = DateTimeOffset.Now;
            }
        }

        public decimal? GetTotal()
        {
            if (EndedOn != null)
            {
                return _type.Rate * (EndedOn - StartedOn).Hours;
            }
            return null;
        }
    }
}