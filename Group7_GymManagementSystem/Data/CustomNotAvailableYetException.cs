using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_GymManagementSystem.Data
{
    // Custom exception class to indicate that a requested feature or action is not available yet. Accepts a custom error message
    public class CustomNotAvailableYetException : Exception
    {
        public CustomNotAvailableYetException(string message) : base(message) { }
    }
}
