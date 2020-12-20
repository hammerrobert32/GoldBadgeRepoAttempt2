using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgesRepo
    {
        Dictionary<int, BadgesPoco> _badgeDictionary = new Dictionary<int, BadgesPoco>();


        //Create
        public void AddNewBadge(int badgeId, BadgesPoco badge)
        {
            _badgeDictionary.Add(badgeId, badge);
        }

        //Read
        public Dictionary<int, BadgesPoco> ViewAllBadges()
        {
            return _badgeDictionary;
        }

        //Update
        public bool EditBadge(int key, BadgesPoco newBadge)
        {
            BadgesPoco oldBadge = GetBadgeByKey(key);

            if(oldBadge != null)
            {
                oldBadge.Badge = newBadge.Badge;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveAllDoorsFromBadge(int key)
        {
            BadgesPoco badge = GetBadgeByKey(key);

            if (badge == null)
            {
                return false;
            }

            int initialCount = _badgeDictionary.Count();
            _badgeDictionary.Remove(badge);

            if (initialCount > _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public BadgesPoco GetBadgeByKey(int key)
        {
            if (_badgeDictionary.ContainsKey(key))
            {
                return _badgeDictionary[key];
            }
            else
            {
                return null;
            }
        }
    }
}
