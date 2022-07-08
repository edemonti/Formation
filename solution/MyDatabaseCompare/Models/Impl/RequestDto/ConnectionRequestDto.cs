namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="Connection"/>.
    /// </summary>
    public class ConnectionRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="Connection.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="Connection.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="Connection.Provider"/>.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// <see cref="Connection.IsProviderImplemented"/>.
        /// </summary>
        public bool IsProviderImplemented { get; set; }

        /// <summary>
        /// <see cref="Connection.ConnectionString"/>.
        /// </summary>
        public string ConnectionStringLike { get; set; }

        #endregion

        #region Specified properties

        /// <summary>
        /// Flag indiquant si la propritété "Id" est spécifiée.
        /// </summary>
        public bool IsIdSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "Name" est spécifiée.
        /// </summary>
        public bool IsNameSpecified { get; set; }
        /// <summary>
        /// Flag indiquant si la propritété "Provider" est spécifiée.
        /// </summary>
        public bool IsProviderSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IsProviderImplemented" est spécifiée.
        /// </summary>
        public bool IsIsProviderImplementedSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "ConnectionStringLike" est spécifiée.
        /// </summary>
        public bool IsConnectionStringLikeSpecified { get; set; }

        #endregion

    }
}