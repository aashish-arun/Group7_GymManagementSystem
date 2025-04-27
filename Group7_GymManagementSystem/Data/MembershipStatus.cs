using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_GymManagementSystem.Data
{
    // You can basically have the values Active or Inactive for MembershipType property 
    // Could have used bool to but prefered enum so we can do the drop down menu
    public enum MembershipStatus
    {
        Active,
        Inactive
    }
}
