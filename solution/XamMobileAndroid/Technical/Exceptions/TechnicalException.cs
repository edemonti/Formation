using System;

namespace Technical.Exceptions
{
    /// <summary>
    /// Exception technique.
    /// </summary>
    public class TechnicalException : BaseException
    {
        #region Constructors

        public TechnicalException(string message)
            : base(message)
        {
        }

        public TechnicalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}