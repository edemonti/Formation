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
    /// Voir <see cref="IExecutionActionDetailDataAccess"/>.
    /// </summary>
    public class ExecutionActionDetailDataAccess : IExecutionActionDetailDataAccess
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
        public ExecutionActionDetailDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailDataAccess.GetEntities(ExecutionActionDetailRequestDto, List{string})"/>.
        /// </summary>
        public List<ExecutionActionDetail> GetEntities(ExecutionActionDetailRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.ExecutionActionDetailXmlFile);
            var xmlEntities = xdoc.Root.Elements("executionActionDetail");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new ExecutionActionDetail
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    IdExecutionAction = int.Parse(s.Attribute("idExecutionAction").Value),
                    DigitalSignature = s.Attribute("digitalSignature").Value,
                    Count = int.Parse(s.Attribute("count").Value),
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsIdExecutionActionSpecified || (requestDto.IsIdExecutionActionSpecified && w.IdExecutionAction == requestDto.IdExecutionAction))
                .ToList();

            // Récupération des propriétés de navigation.
            if (includes.Any())
            {
                foreach (var entity in entities)
                {
                    if (includes.Any(w => (w.Equals("ExecutionAction") || w.EndsWith(".ExecutionAction"))))
                    {
                        entity.ExecutionAction = ServiceLocator.Current.GetInstance<IExecutionActionDataAccess>()
                            .GetEntity(entity.IdExecutionAction, includes.Where(w => !w.Equals("ExecutionAction") && w.Contains("ExecutionAction")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public ExecutionActionDetail GetEntity(int id, List<string> includes)
        {
            var requestDto = new ExecutionActionDetailRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailDataAccess.InsertEntity(ExecutionActionDetail, BaseExecuteDto)"/>.
        /// </summary>
        public ExecutionActionDetail InsertEntity(ExecutionActionDetail entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.ExecutionActionDetailXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("executionActionDetail",
                new XAttribute("id", entity.Id),
                new XAttribute("idExecutionAction", entity.IdExecutionAction),
                new XAttribute("digitalSignature", entity.DigitalSignature),
                new XAttribute("count", entity.Count)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.ExecutionActionDetailXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDetailDataAccess.InsertEntities(List{ExecutionActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ExecutionActionDetail> InsertEntities(List<ExecutionActionDetail> entities, BaseExecuteDto executeDto)
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
