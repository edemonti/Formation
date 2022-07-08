namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="ActionDetail"/>.
    /// </summary>
    public class ActionDetailRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="ActionDetail.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="ActionDetail.IdAction"/>.
        /// </summary>
        public int IdAction { get; set; }

        /// <summary>
        /// <see cref="ActionDetail.IdConnection"/>.
        /// </summary>
        public int IdConnection { get; set; }

        /// <summary>
        /// <see cref="ActionDetail.IdQuery"/>.
        /// </summary>
        public int IdQuery { get; set; }

        /// <summary>
        /// <see cref="ActionDetail.Where"/>.
        /// </summary>
        public string WhereLike { get; set; }

        #endregion

        #region Specified properties

        /// <summary>
        /// Flag indiquant si la propritété "Id" est spécifiée.
        /// </summary>
        public bool IsIdSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdAction" est spécifiée.
        /// </summary>
        public bool IsIdActionSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdConnection" est spécifiée.
        /// </summary>
        public bool IsIdConnectionSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdQuery" est spécifiée.
        /// </summary>
        public bool IsIdQuerySpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "WhereLike" est spécifiée.
        /// </summary>
        public bool IsWhereLikeSpecified { get; set; }

        #endregion

    }
}