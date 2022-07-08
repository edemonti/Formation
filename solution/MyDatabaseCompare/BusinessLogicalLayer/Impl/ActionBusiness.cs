using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IActionBusiness"/>.
    /// </summary>
    public class ActionBusiness : IActionBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IActionDataAccess.
        /// </summary>
        private readonly IActionDataAccess actionDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="actionDataAccess">Instance de la classe IActionDataAccess.</param>
        public ActionBusiness(IActionDataAccess actionDataAccess)
        {
            this.actionDataAccess = actionDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IActionBusiness.GetEntities(ActionRequestDto, List{string})"/>.
        /// </summary>
        public List<Action> GetEntities(ActionRequestDto requestDto, List<string> includes)
        {
            return actionDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IActionBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public Action GetEntity(int id, List<string> includes)
        {
            return actionDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IActionBusiness.InsertEntity(Action, BaseExecuteDto)"/>.
        /// </summary>
        public Action InsertEntity(Action entity, BaseExecuteDto executeDto)
        {
            return actionDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IActionBusiness.InsertEntities(List{Action}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Action> InsertEntities(List<Action> entities, BaseExecuteDto executeDto)
        {
            return actionDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}