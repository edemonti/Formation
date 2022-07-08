using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IActionDetailBusiness"/>.
    /// </summary>
    public class ActionDetailBusiness : IActionDetailBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IActionDetailDataAccess.
        /// </summary>
        private readonly IActionDetailDataAccess actionDetailDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="actionDetailDataAccess">Instance de la classe IActionDetailDataAccess.</param>
        public ActionDetailBusiness(IActionDetailDataAccess actionDetailDataAccess)
        {
            this.actionDetailDataAccess = actionDetailDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IActionDetailBusiness.GetEntities(ActionDetailRequestDto, List{string})"/>.
        /// </summary>
        public List<ActionDetail> GetEntities(ActionDetailRequestDto requestDto, List<string> includes)
        {
            return actionDetailDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IActionDetailBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public ActionDetail GetEntity(int id, List<string> includes)
        {
            return actionDetailDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IActionDetailBusiness.InsertEntity(ActionDetail, BaseExecuteDto)"/>.
        /// </summary>
        public ActionDetail InsertEntity(ActionDetail entity, BaseExecuteDto executeDto)
        {
            return actionDetailDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IActionDetailBusiness.InsertEntities(List{ActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ActionDetail> InsertEntities(List<ActionDetail> entities, BaseExecuteDto executeDto)
        {
            return actionDetailDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}