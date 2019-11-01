using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class EditWorkDone
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WorkTypeId { get; set; }

        [DisplayName("Started On:"),
         DataType(DataType.DateTime)]
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
        public List<SelectListItem> ClientItems { get; set; }
        public List<SelectListItem> WorkTypeItems { get; set; }

        public string BuildDateTimeString(DateTimeOffset dt)
        {
            string year = dt.Year.ToString();
            string month = dt.Month.ToString().PadLeft(2, '0');
            string day = dt.Day.ToString().PadLeft(2, '0');
            string hour = dt.Hour.ToString().PadLeft(2, '0');
            string minute = dt.Minute.ToString().PadLeft(2, '0');
            string second = dt.Second.ToString().PadLeft(2, '0');
            string millisecond = dt.Millisecond.ToString();
            return $"{year}-{month}-{day}T{hour}:{minute}:{second}.{millisecond}";
        }
    }
}