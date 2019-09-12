﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class CommunityRole
    {
        public int CommunityId { get; set; }
        public string RoleName { get; set; }

        public override string ToString()
        {
            return $"CommunityId: {CommunityId}, RoleName: {RoleName}";
        }
    }
}