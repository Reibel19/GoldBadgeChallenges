using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB3_ClassLibrary
{
    public class BadgeRepo
    {
        //         key  value
        Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        //create
        public void AddNewBadge(Badge badge)
        {
            //                      KEY         value
            _badgeDictionary.Add(badge.BadgeID, badge);
        }

        //when foreaching over your dictionary, you will have an option for "Key" and "Value"

        //read
        public Dictionary<int, Badge> GetDictionary()
        {
            return _badgeDictionary;
        }


        //upodate method part 2 electric boogaloo
        public bool AddUpdateMeth(int badgeID, string doorName)
        {
            Badge oldBadge = GetBadgeByID(badgeID);
            if (oldBadge != null)
            {
                oldBadge.ListOfDoorAccess.Add(doorName);
                return true;
            }
            return false;
        }

        public bool RemoveUpdateMeth(int badgeID, string doorName)
        {
            Badge oldBadge = GetBadgeByID(badgeID);
            if (oldBadge != null)
            {
                oldBadge.ListOfDoorAccess.Remove(doorName);
                return true;
            }
            return false;
        }


        //delete
        public bool ClearDoorAccess(int badgeID)
        {
            Badge getById = GetBadgeByID(badgeID);

            if (getById == null)
            {
                return false;
            }

            int count = getById.ListOfDoorAccess.Count;

            getById.ListOfDoorAccess.Clear();
            if (count > getById.ListOfDoorAccess.Count)
            {
                return true;
            }
            return false;


        }

        //helper method
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> item in _badgeDictionary)
            {
                if (item.Value.BadgeID == badgeID)
                {
                    return item.Value;
                }
            }
            return null;
        }




    }
}
