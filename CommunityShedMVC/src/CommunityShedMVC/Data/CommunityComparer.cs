using CommunityShedMVC.Models;
using System.Collections.Generic;

namespace CommunityShedMVC.Data
{
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