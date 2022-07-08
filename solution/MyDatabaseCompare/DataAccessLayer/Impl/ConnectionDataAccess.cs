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
    /// Voir <see cref="IConnectionDataAccess"/>.
    /// </summary>
    public class ConnectionDataAccess : IConnectionDataAccess
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
        public ConnectionDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IConnectionDataAccess.GetEntities(ConnectionRequestDto, List{string})"/>.
        /// </summary>
        public List<Connection> GetEntities(ConnectionRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.ConnectionXmlFile);
            var xmlEntities = xdoc.Root.Elements("connection");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new Connection
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    Name = s.Attribute("name").Value,
                    Provider = s.Attribute("provider").Value,
                    IsProviderImplemented = bool.Parse(s.Attribute("isProviderImplemented").Value),
                    ConnectionString = s.Attribute("connectionString").Value
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsIsProviderImplementedSpecified || (requestDto.IsIsProviderImplementedSpecified && w.IsProviderImplemented == requestDto.IsProviderImplemented))
                .Where(w => !requestDto.IsNameSpecified || (requestDto.IsNameSpecified && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsProviderSpecified || (requestDto.IsProviderSpecified && w.Provider == requestDto.Provider))
                .Where(w => !requestDto.IsConnectionStringLikeSpecified || (requestDto.IsConnectionStringLikeSpecified && w.ConnectionString.Contains(requestDto.ConnectionStringLike)))
                .ToList();

            // Récupération des propriétés de navigation.
            if (includes.Any())
            {
                foreach (var entity in entities)
                {
                    if (includes.Any(w => (w.Equals("ActionDetailList") || w.EndsWith(".ActionDetailList"))))
                    {
                        var childRequestDto = new ActionDetailRequestDto { IdConnection = entity.Id, IsIdConnectionSpecified = true };
                        entity.ActionDetailList = ServiceLocator.Current.GetInstance<IActionDetailDataAccess>()
                            .GetEntities(childRequestDto, includes.Where(w => !w.Equals("ActionDetailList") && w.Contains("ActionDetailList")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IConnectionDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public Connection GetEntity(int id, List<string> includes)
        {
            var requestDto = new ConnectionRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IConnectionDataAccess.InsertEntity(Connection, BaseExecuteDto)"/>.
        /// </summary>
        public Connection InsertEntity(Connection entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.ConnectionXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("connection",
                new XAttribute("id", entity.Id),
                new XAttribute("name", entity.Name),
                new XAttribute("provider", entity.Provider),
                new XAttribute("isProviderImplemented", entity.IsProviderImplemented),
                new XAttribute("connectionString", entity.ConnectionString)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.ConnectionXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IConnectionDataAccess.InsertEntities(List{Connection}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Connection> InsertEntities(List<Connection> entities, BaseExecuteDto executeDto)
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
