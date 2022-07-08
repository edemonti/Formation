using System;
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
    /// Voir <see cref="IExecutionActionDataAccess"/>.
    /// </summary>
    public class ExecutionActionDataAccess : IExecutionActionDataAccess
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
        public ExecutionActionDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDataAccess.GetEntities(ExecutionActionRequestDto, List{string})"/>.
        /// </summary>
        public List<ExecutionAction> GetEntities(ExecutionActionRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.ExecutionActionXmlFile);
            var xmlEntities = xdoc.Root.Elements("executionAction");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new ExecutionAction
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    IdAction = int.Parse(s.Attribute("idAction").Value),
                    IdExecutionActionDetail1 = int.Parse(s.Attribute("idExecutionActionDetail1").Value),
                    IdExecutionActionDetail2 = int.Parse(s.Attribute("idExecutionActionDetail2").Value),
                    ExecutionDate = DateTime.Parse(s.Attribute("executionDate").Value),
                    ErrorMessage = s.Attribute("errorMessage").Value
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsIdActionSpecified || (requestDto.IsIdActionSpecified && w.IdAction == requestDto.IdAction))
                .Where(w => !requestDto.IsIdExecutionActionDetail1Specified || (requestDto.IsIdExecutionActionDetail1Specified && w.IdExecutionActionDetail1 == requestDto.IdExecutionActionDetail1))
                .Where(w => !requestDto.IsIdExecutionActionDetail2Specified || (requestDto.IsIdExecutionActionDetail2Specified && w.IdExecutionActionDetail2 == requestDto.IdExecutionActionDetail2))
                .Where(w => !requestDto.IsIsActionsEqualsSpecified || (requestDto.IsIsActionsEqualsSpecified && w.IsActionsEquals == requestDto.IsActionsEquals))
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
                    if (includes.Any(w => (w.Equals("ExecutionActionDetail1") || w.EndsWith(".ExecutionActionDetail1"))))
                    {
                        entity.ExecutionActionDetail1 = ServiceLocator.Current.GetInstance<IExecutionActionDetailDataAccess>()
                            .GetEntity(entity.IdExecutionActionDetail1, includes.Where(w => !w.Equals("ExecutionActionDetail1") && w.Contains("ExecutionActionDetail1")).ToList());
                    }
                    if (includes.Any(w => (w.Equals("ExecutionActionDetail2") || w.EndsWith(".ExecutionActionDetail2"))))
                    {
                        entity.ExecutionActionDetail2 = ServiceLocator.Current.GetInstance<IExecutionActionDetailDataAccess>()
                            .GetEntity(entity.IdExecutionActionDetail2, includes.Where(w => !w.Equals("ExecutionActionDetail2") && w.Contains("ExecutionActionDetail2")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public ExecutionAction GetEntity(int id, List<string> includes)
        {
            var requestDto = new ExecutionActionRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IExecutionActionDataAccess.InsertEntity(ExecutionAction, BaseExecuteDto)"/>.
        /// </summary>
        public ExecutionAction InsertEntity(ExecutionAction entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.ExecutionActionXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("executionAction",
                new XAttribute("id", entity.Id),
                new XAttribute("idAction", entity.IdAction),
                new XAttribute("idExecutionActionDetail1", entity.IdExecutionActionDetail1),
                new XAttribute("idExecutionActionDetail2", entity.IdExecutionActionDetail2),
                new XAttribute("executionDate", entity.ExecutionDate.ToString("dd/MM/yyyy HH:mm:ss")),
                new XAttribute("isActionsEquals", !entity.IsActionsEquals.HasValue ? string.Empty : entity.IsActionsEquals.GetValueOrDefault().ToString()),
                new XAttribute("errorMessage", entity.ErrorMessage)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.ExecutionActionXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IExecutionActionDataAccess.InsertEntities(List{ExecutionAction}, BaseExecuteDto)"/>.
        /// </summary>
        public List<ExecutionAction> InsertEntities(List<ExecutionAction> entities, BaseExecuteDto executeDto)
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