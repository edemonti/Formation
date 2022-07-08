namespace Models.Impl.RequestDto
{
    /// <summary>
    /// Dto de recherche pour l’entité <see cref="Action"/>.
    /// </summary>
    public class ActionRequestDto
    {

        #region Properties

        /// <summary>
        /// <see cref="Action.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="Action.IdActionDetail1"/>
        /// </summary>
        public int IdActionDetail1 { get; set; }

        /// <summary>
        /// <see cref="Action.IdActionDetail2"/>
        /// </summary>
        public int IdActionDetail2 { get; set; }

        /// <summary>
        /// <see cref="Action.IsActionEnabled"/>.
        /// </summary>
        public bool IsActionEnabled { get; set; }

        #endregion

        #region Specified properties

        /// <summary>
        /// Flag indiquant si la propritété "Id" est spécifiée.
        /// </summary>
        public bool IsIdSpecified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdActionDetail1" est spécifiée.
        /// </summary>
        public bool IsIdActionDetail1Specified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IdActionDetail2" est spécifiée.
        /// </summary>
        public bool IsIdActionDetail2Specified { get; set; }

        /// <summary>
        /// Flag indiquant si la propritété "IsActionEnabled" est spécifiée.
        /// </summary>
        public bool IsIsActionEnabledSpecified { get; set; }

        #endregion

    }
}