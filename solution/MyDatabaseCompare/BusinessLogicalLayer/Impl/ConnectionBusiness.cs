using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IConnectionBusiness"/>.
    /// </summary>
    public class ConnectionBusiness : IConnectionBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IConnectionDataAccess.
        /// </summary>
        private readonly IConnectionDataAccess connectionDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="connectionDataAccess">Instance de la classe IConnectionDataAccess.</param>
        public ConnectionBusiness(IConnectionDataAccess connectionDataAccess)
        {
            this.connectionDataAccess = connectionDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IConnectionBusiness.GetEntities(ConnectionRequestDto, List{string})"/>.
        /// </summary>
        public List<Connection> GetEntities(ConnectionRequestDto requestDto, List<string> includes)
        {
            return connectionDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IConnectionBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public Connection GetEntity(int id, List<string> includes)
        {
            return connectionDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IConnectionBusiness.InsertEntity(Connection, BaseExecuteDto)"/>.
        /// </summary>
        public Connection InsertEntity(Connection entity, BaseExecuteDto executeDto)
        {
            return connectionDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IConnectionBusiness.InsertEntities(List{Connection}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Connection> InsertEntities(List<Connection> entities, BaseExecuteDto executeDto)
        {
            return connectionDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}