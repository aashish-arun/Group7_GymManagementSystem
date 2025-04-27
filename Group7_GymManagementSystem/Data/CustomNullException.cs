using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_GymManagementSystem.Data
{
    // Custom exception class to handle null-related errors. Accepts a custom error message
    public class CustomNullException : Exception
    {
        public CustomNullException(string message) : base(message) { }
    }
}
