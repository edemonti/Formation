namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="ExecutionActionDetail"/>.
    /// </summary>
    public class ExecutionActionDetailRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="ExecutionActionDetail.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="ExecutionActionDetail.IdExecutionAction"/>.
        /// </summary>
        public int IdExecutionAction { get; set; }

        #endregion

        #region Specified properties

        /// <summary>
        /// Flag indiquant si la propritété "Id" est spécifiée.
        /// </summary>
        public bool IsIdSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdExecutionAction" est spécifiée.
        /// </summary>
        public bool IsIdExecutionActionSpecified { get; set; }

        #endregion

    }
}