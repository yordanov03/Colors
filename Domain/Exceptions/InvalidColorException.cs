using Colors.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidColorException : BaseDomainException
    {
        public InvalidColorException() { }

        public InvalidColorException(string message) => this.Message = message;

    }
}
