namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="Query"/>.
    /// </summary>
    public class QueryRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="Query.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="Query.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="Query.Command"/>.
        /// </summary>
        public string CommandLike { get; set; }

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
        /// Flag indiquant si la propritété "CommandLike" est spécifiée.
        /// </summary>
        public bool IsCommandLikeSpecified { get; set; }

        #endregion

    }
}