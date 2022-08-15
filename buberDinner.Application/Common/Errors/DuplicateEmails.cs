namespace buberDinner.Application.Common.Errors;
public class DuplicateEmailException : Exception
{
    public DuplicateEmailException (string message) : base(message)
    {
    }
    public DuplicateEmailException ()
    {
    }

    protected DuplicateEmailException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
    }

    public DuplicateEmailException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}