using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task5
    {
        public static string InvitationList(string s)
        {
            if (s == "")
                return "There is no guests";
            var guests = s.ToUpper().Split(';');

            var sortedGuests = guests.Select(guest =>
            {
                var parts = guest.Split(':');
                var firstName = parts[0];
                var lastName = parts[1];
                return (lastName, firstName);
            })
            .OrderBy(guest => guest.lastName)
            .ThenBy(guest => guest.firstName)
            .Select(guest => $"({guest.lastName}, {guest.firstName})");

            return string.Concat(sortedGuests);
        }
    }
}
