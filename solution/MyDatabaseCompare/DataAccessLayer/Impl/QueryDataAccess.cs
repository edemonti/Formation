using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataAccessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;
using Models.Technical;

namespace DataAccessLayer.Impl
{
    /// <summary>
    /// Voir <see cref="IQueryDataAccess"/>.
    /// </summary>
    public class QueryDataAccess : IQueryDataAccess
    {

        #region Attributs

        /// <summary>
        /// Contexte
        /// </summary>
        private readonly Context context;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="context">Contexte.</param>
        public QueryDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IQueryDataAccess.GetEntities(QueryRequestDto, List{string})"/>.
        /// </summary>
        public List<Query> GetEntities(QueryRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.QueryXmlFile);
            var xmlEntities = xdoc.Root.Elements("query");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new Query
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    Name = s.Attribute("name").Value,
                    Command = s.Attribute("command").Value
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsNameSpecified || (requestDto.IsNameSpecified && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsCommandLikeSpecified || (requestDto.IsCommandLikeSpecified && w.Command.Contains(requestDto.CommandLike)))
                .ToList();

            // Récupération des propriétés de navigation.
            if (includes.Any())
            {
                foreach (var entity in entities)
                {
                    if (includes.Any(w => (w.Equals("ActionDetailList") || w.EndsWith(".ActionDetailList"))))
                    {
                        var childRequestDto = new ActionDetailRequestDto { IdQuery = entity.Id, IsIdQuerySpecified = true };
                        entity.ActionDetailList = ServiceLocator.Current.GetInstance<IActionDetailDataAccess>()
                            .GetEntities(childRequestDto, includes.Where(w => !w.Equals("ActionDetailList") && w.Contains("ActionDetailList")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IQueryDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public Query GetEntity(int id, List<string> includes)
        {
            var requestDto = new QueryRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IQueryDataAccess.InsertEntity(Query, BaseExecuteDto)"/>.
        /// </summary>
        public Query InsertEntity(Query entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.QueryXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("query",
                new XAttribute("id", entity.Id),
                new XAttribute("name", entity.Name),
                new XAttribute("command", entity.Command)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.QueryXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IQueryDataAccess.InsertEntities(List{Query}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Query> InsertEntities(List<Query> entities, BaseExecuteDto executeDto)
        {
            foreach (var entity in entities)
            {
                InsertEntity(entity, executeDto);
            }
            return entities;
        }
        #endregion

    }
}
