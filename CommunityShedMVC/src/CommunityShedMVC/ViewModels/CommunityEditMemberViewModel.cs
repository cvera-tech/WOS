using CommunityShedMVC.Models;
using System.Collections.Generic;

namespace CommunityShedMVC.ViewModels
{
    public class CommunityEditMemberViewModel
    {
        public Community Community { get; set; }
        public bool Approver { get; set; }
        public bool Reviewer { get; set; }
        public bool Enforcer { get; set; }
    }
}