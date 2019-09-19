using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class CommunityListItem : Community
    {
        public bool IsMember { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Member: {IsMember}";
        }
    }
}