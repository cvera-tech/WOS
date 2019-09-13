using CommunityShedMVC.Models;
using System.Linq;
using System.Collections.Generic;
using System;

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

    class CommunityComparer : IEqualityComparer<Community>
    {
        public bool Equals(Community x, Community y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Community obj)
        {
            return obj.Id;
        }
    }
}