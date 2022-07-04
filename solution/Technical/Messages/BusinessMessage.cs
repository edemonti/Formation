using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Technical.Enums;

namespace Technical.Messages
{
    /// <summary>
    /// Messages métier.
    /// </summary>
    public class BusinessMessage : BaseMessage
    {
        #region Properties

        /// <summary>
        /// Voir <see cref="MessageType"/>.
        /// </summary>
        private MessageType _messageType;
        public MessageType MessageType
        {
            get => _messageType;
            set => SetField(ref _messageType, value);
        }

        /// <summary>
        /// Titre du message.
        /// </summary>
        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        /// <summary>
        /// Titre du message.
        /// </summary>
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                SetField(ref _message, value);
                RaisePropertyChanged("MessageWithDetails");
            }
        }

        /// <summary>
        /// Liste des messages associés à cette exception.
        /// </summary>
        private ObservableCollection<string> _detailMessages;
        public ObservableCollection<string> DetailMessages
        {
            get => _detailMessages;
            set
            {
                SetField(ref _detailMessages, value);
                RaisePropertyChanged("DetailMessagesFormated");
                RaisePropertyChanged("MessageWithDetails");
                RaisePropertyChanged("HasDetails");
            }
        }

        /// <summary>
        /// Liste des messages (formatés) associés à cette exception.
        /// </summary>
        public string DetailMessagesFormated => DetailMessages.Any() ? string.Join(Environment.NewLine, DetailMessages) : string.Empty;

        /// <summary>
        /// Message avec le détail.
        /// </summary>
        public string MessageWithDetails => DetailMessages.Any() ? string.Format("{0}{1}{2}", Message, Environment.NewLine, string.Join(",", DetailMessages)) : Message;

        /// <summary>
        /// Flag indiquant si le message contient un détail.
        /// </summary>
        public bool HasDetails => DetailMessages.Any();

        #endregion

        #region Constructors

        public BusinessMessage(MessageType messageType, string title, string message, IList<string> detailMessages)
        {
            MessageType = messageType;
            Title = title;
            Message = message;
            DetailMessages = new ObservableCollection<string>(detailMessages);
        }

        public BusinessMessage(MessageType messageType, string title, string message)
        {
            MessageType = messageType;
            Title = title;
            Message = message;
            DetailMessages = new ObservableCollection<string>();
        }

        #endregion
    }
}