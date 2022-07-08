using System;
using Technical.Messages;

namespace Technical.Exceptions
{
    /// <summary>
    /// Exception métier.
    /// </summary>
    public class BusinessException : BaseException
    {
        #region Properties

        /// <summary>
        /// Voir <see cref="BusinessMessage"/>.
        /// </summary>
        private BusinessMessage _businessMessage;
        public BusinessMessage BusinessMessage
        {
            get => _businessMessage;
            set => SetField(ref _businessMessage, value);
        }

        /// <summary>
        /// Exception
        /// </summary>
        private Exception _innerException;
        public new Exception InnerException
        {
            get => _innerException;
            set => SetField(ref _innerException, value);
        }

        #endregion

        #region Constructors

        public BusinessException(BusinessMessage businessMessage)
        {
            BusinessMessage = businessMessage;
        }

        public BusinessException(BusinessMessage businessMessage, Exception innerException)
        {
            BusinessMessage = businessMessage;
            InnerException = innerException;
        }

        #endregion
    }
}