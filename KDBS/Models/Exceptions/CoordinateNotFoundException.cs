using System;

namespace KDBS.Models.Exceptions
{
    public class CoordinateNotFoundException : Exception
    {
        public CoordinateNotFoundException(string message) : base(message)
        {

        }
    }
}
