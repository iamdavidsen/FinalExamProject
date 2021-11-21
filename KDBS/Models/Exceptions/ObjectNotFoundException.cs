using System;

namespace KDBS.Models.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {

        }
    }

}
