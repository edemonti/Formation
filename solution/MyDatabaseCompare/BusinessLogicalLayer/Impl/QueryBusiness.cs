using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IQueryBusiness"/>.
    /// </summary>
    public class QueryBusiness : IQueryBusiness
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IQueryDataAccess.
        /// </summary>
        private readonly IQueryDataAccess queryDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="queryDataAccess">Instance de la classe IQueryDataAccess.</param>
        public QueryBusiness(IQueryDataAccess queryDataAccess)
        {
            this.queryDataAccess = queryDataAccess;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IQueryBusiness.GetEntities(QueryRequestDto, List{string})"/>.
        /// </summary>
        public List<Query> GetEntities(QueryRequestDto requestDto, List<string> includes)
        {
            return queryDataAccess.GetEntities(requestDto, includes);
        }

        /// <summary>
        /// Voir <see cref="IQueryBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        public Query GetEntity(int id, List<string> includes)
        {
            return queryDataAccess.GetEntity(id, includes);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IQueryBusiness.InsertEntity(Query, BaseExecuteDto)"/>.
        /// </summary>
        public Query InsertEntity(Query entity, BaseExecuteDto executeDto)
        {
            return queryDataAccess.InsertEntity(entity, executeDto);
        }

        /// <summary>
        /// Voir <see cref="IQueryBusiness.InsertEntities(List{Query}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Query> InsertEntities(List<Query> entities, BaseExecuteDto executeDto)
        {
            return queryDataAccess.InsertEntities(entities, executeDto);
        }

        #endregion

    }
}