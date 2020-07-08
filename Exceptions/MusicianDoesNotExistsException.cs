using System;

namespace SampleAPI.Exceptions
{
    public class MusicianDoesNotExistsException : Exception
    {
        public MusicianDoesNotExistsException()
        {
        }

        public MusicianDoesNotExistsException(string message) : base(message)
        {
        }

        public MusicianDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
