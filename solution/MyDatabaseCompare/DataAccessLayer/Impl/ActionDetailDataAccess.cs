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
    /// Voir <see cref="IActionDetailDataAccess"/>.
    /// </summary>
    public class ActionDetailDataAccess : IActionDetailDataAccess
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
        public ActionDetailDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IActionDetailDataAccess.GetEntities(ActionDetailRequestDto, List{string})"/>.
        /// </summary>
        public List<ActionDetail> GetEntities(ActionDetailRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.ActionDetailXmlFile);
            var xmlEntities = xdoc.Root.Elements("actionDetail");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new ActionDetail
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    IdAction = int.Parse(s.Attribute("idAction").Value),
                    IdConnection = int.Parse(s.Attribute("idConnection").Value),
                    IdQuery = int.Parse(s.Attribute("idQuery").Value),
                    Where = s.Attribute("where").Value,
                    IsExportCsvEnabled = bool.Parse(s.Attribute("isExportCsvEnabled").Value),
                    IsExportXmlEnabled = bool.Parse(s.Attribute("isExportXmlEnabled").Value)
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsIdActionSpecified || (requestDto.IsIdActionSpecified && w.IdAction == requestDto.IdAction))
                .Where(w => !requestDto.IsIdConnectionSpecified || (requestDto.IsIdConnectionSpecified && w.IdConnection == requestDto.IdConnection))
                .Where(w => !requestDto.IsIdQuerySpecified || (requestDto.IsIdQuerySpecified && w.IdQuery == requestDto.IdQuery))
                .Where(w => !requestDto.IsWhereLikeSpecified || (requestDto.IsWhereLikeSpecified && w.Where.Contains(requestDto.WhereLike)))
                .ToList();

            // Récupération des propriétés de navigation.
            if (includes.Any())
            {
                foreach (var entity in entities)
                {
                    if (includes.Any(w => (w.Equals("Action") || w.EndsWith(".Action"))))
                    {
                        entity.Action = ServiceLocator.Current.GetInstance<IActionDataAccess>()
                            .GetEntity(entity.IdAction, includes.Where(w => !w.Equals("Action") && w.Contains("Action")).ToList());
                    }

                    if (includes.Any(w => (w.Equals("Connection") || w.EndsWith(".Connection"))))
                    {
                        entity.Connection = ServiceLocator.Current.GetInstance<IConnectionDataAccess>()
                            .GetEntity(entity.IdConnection, includes.Where(w => !w.Equals("Connection") && w.Contains("Connection")).ToList());
                    }

                    if (includes.Any(w => (w.Equals("Query") || w.EndsWith(".Query"))))
                    {
                        entity.Query = ServiceLocator.Current.GetInstance<IQueryDataAccess>()
                            .GetEntity(entity.IdQuery, includes.Where(w => !w.Equals("Query") && w.Contains("Query")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IActionDetailDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public ActionDetail GetEntity(int id, List<string> includes)
        {
            var requestDto = new ActionDetailRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IActionDetailDataAccess.InsertEntity(ActionDetail, BaseExecuteDto)"/>.
        /// </summary>
        public ActionDetail InsertEntity(ActionDetail entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.ActionDetailXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("actionDetail",
                new XAttribute("id", entity.Id),
                new XAttribute("idAction", entity.IdAction),
                new XAttribute("idConnection", entity.IdConnection),
                new XAttribute("idQuery", entity.IdQuery),
                new XAttribute("where", entity.Where),
                new XAttribute("isExportCsvEnabled", entity.IsExportCsvEnabled),
                new XAttribute("isExportXmlEnabled", entity.IsExportXmlEnabled)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.ActionDetailXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IActionDetailDataAccess.InsertEntities(List{ActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ActionDetail> InsertEntities(List<ActionDetail> entities, BaseExecuteDto executeDto)
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
