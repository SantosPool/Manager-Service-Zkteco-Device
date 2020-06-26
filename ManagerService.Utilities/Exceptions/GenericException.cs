using System;
using System.Globalization;

namespace ManagerService.Utilities
{
    public class GenericException : SystemException
    {
        public GenericException() : base() { }

        public GenericException(string message) : base(message) { }

        public GenericException(string message, params string[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
