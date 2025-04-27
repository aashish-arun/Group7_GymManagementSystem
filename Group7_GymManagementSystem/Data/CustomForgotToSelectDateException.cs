using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_GymManagementSystem.Data
{
    // Custom exception class for handling cases where a scheduled date is not selected. Provides a default error message.
    class CustomForgotToSelectDateException  : Exception
    {
        public CustomForgotToSelectDateException()
            : base("Scheduled date is not selected. Please choose a valid date.") { }
    }
}
