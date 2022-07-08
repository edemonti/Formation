namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="ExecutionAction"/>.
    /// </summary>
    public class ExecutionActionRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="ExecutionAction.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="ExecutionAction.IdAction"/>.
        /// </summary>
        public int IdAction { get; set; }

        /// <summary>
        /// <see cref="ExecutionAction.IdExecutionActionDetail1"/>.
        /// </summary>
        public int IdExecutionActionDetail1 { get; set; }

        /// <summary>
        /// <see cref="ExecutionAction.IdExecutionActionDetail2"/>.
        /// </summary>
        public int IdExecutionActionDetail2 { get; set; }

        /// <summary>
        /// <see cref="ExecutionAction.IsActionsEquals"/>.
        /// </summary>
        public bool IsActionsEquals { get; set; }

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
        /// Flag indiquant si la propritété "IdExecutionActionDetail1" est spécifiée.
        /// </summary>
        public bool IsIdExecutionActionDetail1Specified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdExecutionActionDetail2" est spécifiée.
        /// </summary>
        public bool IsIdExecutionActionDetail2Specified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IsActionsEquals" est spécifiée.
        /// </summary>
        public bool IsIsActionsEqualsSpecified { get; set; }

        #endregion

    }
}