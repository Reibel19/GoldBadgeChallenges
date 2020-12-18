using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB3_ClassLibrary
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoorAccess { get; set; } = new List<string>();

        public Badge() { }

        public Badge(int badgeID, List<string> listOfDoorAccess)
        {
            BadgeID = badgeID;
            ListOfDoorAccess = listOfDoorAccess;
        }
    }
}
