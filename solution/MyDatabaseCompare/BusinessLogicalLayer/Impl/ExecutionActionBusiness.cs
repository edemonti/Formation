using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IExecutionActionBusiness"/>.
    /// </summary>
    public class ExecutionActionBusiness : IExecutionActionBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IExecutionActionDataAccess.
        /// </summary>
        private readonly IExecutionActionDataAccess executionActionDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="executionActionDataAccess">Instance de la classe IExecutionActionDataAccess.</param>
        public ExecutionActionBusiness(IExecutionActionDataAccess executionActionDataAccess)
        {
            this.executionActionDataAccess = executionActionDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IExecutionActionBusiness.GetEntities(ExecutionActionRequestDto, List{string})"/>.
        /// </summary>
        public List<ExecutionAction> GetEntities(ExecutionActionRequestDto requestDto, List<string> includes)
        {
            return executionActionDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public ExecutionAction GetEntity(int id, List<string> includes)
        {
            return executionActionDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IExecutionActionBusiness.InsertEntity(ExecutionAction, BaseExecuteDto)"/>.
        /// </summary>
        public ExecutionAction InsertEntity(ExecutionAction entity, BaseExecuteDto executeDto)
        {
            return executionActionDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionBusiness.InsertEntities(List{ExecutionAction}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ExecutionAction> InsertEntities(List<ExecutionAction> entities, BaseExecuteDto executeDto)
        {
            return executionActionDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}