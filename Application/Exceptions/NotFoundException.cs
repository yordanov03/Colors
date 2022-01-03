using System;

namespace Colors.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
<<<<<<< HEAD
            : base($"Entity '{name}' {key} was not found.")
=======
            : base($"Entity {name} {key} was not found.")
>>>>>>> development
        {
        }
    }
}
