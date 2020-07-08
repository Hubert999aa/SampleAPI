using System;

namespace SampleAPI.Exceptions
{
    public class MusicLabelDoNotExistsException : Exception
    {
        public MusicLabelDoNotExistsException()
        {
        }

        public MusicLabelDoNotExistsException(string message) : base(message)
        {
        }

        public MusicLabelDoNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
