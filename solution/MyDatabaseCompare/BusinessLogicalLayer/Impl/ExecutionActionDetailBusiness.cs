using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IExecutionExecutionActionDetailDetailBusiness"/>.
    /// </summary>
    public class ExecutionActionDetailBusiness : IExecutionActionDetailBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IExecutionActionDetailDataAccess.
        /// </summary>
        private readonly IExecutionActionDetailDataAccess executionActionDetailDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="executionActionDetailDataAccess">Instance de la classe IExecutionActionDetailDataAccess.</param>
        public ExecutionActionDetailBusiness(IExecutionActionDetailDataAccess executionActionDetailDataAccess)
        {
            this.executionActionDetailDataAccess = executionActionDetailDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailBusiness.GetEntities(ExecutionActionDetailRequestDto, List{string})"/>.
        /// </summary>
        public List<ExecutionActionDetail> GetEntities(ExecutionActionDetailRequestDto requestDto, List<string> includes)
        {
            return executionActionDetailDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public ExecutionActionDetail GetEntity(int id, List<string> includes)
        {
            return executionActionDetailDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailBusiness.InsertEntity(ExecutionActionDetail, BaseExecuteDto)"/>.
        /// </summary>
        public ExecutionActionDetail InsertEntity(ExecutionActionDetail entity, BaseExecuteDto executeDto)
        {
            return executionActionDetailDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailBusiness.InsertEntities(List{ExecutionActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ExecutionActionDetail> InsertEntities(List<ExecutionActionDetail> entities, BaseExecuteDto executeDto)
        {
            return executionActionDetailDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}