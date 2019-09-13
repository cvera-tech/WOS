using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommunityShedMVC.ViewModels
{
    public class CommunityListViewModel
    {
        public List<Community> Communities { get; set; }
        public List<Community> JoinedCommunities { get; set; }

        public bool UserIsMember(Community community)
        {
            return JoinedCommunities.Contains(community, new CommunityComparer());
        }
    }
}