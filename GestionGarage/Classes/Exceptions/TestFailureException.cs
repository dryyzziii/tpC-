using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Exceptions
{
    public class TestFailureException : Exception
    {
        public TestFailureException(string testName, string message)
            : base($"Test '{testName}' a échoué : {message}")
        {
        }
    }
}
