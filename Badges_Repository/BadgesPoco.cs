using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgesPoco
    {
        public int BadgeId { get; set; }
        public string Badge { get; set; }

        public BadgesPoco() { }
        public BadgesPoco(int badgeId, string badge)
        {
            BadgeId = badgeId;
            Badge = badge;
        }
    }
}
