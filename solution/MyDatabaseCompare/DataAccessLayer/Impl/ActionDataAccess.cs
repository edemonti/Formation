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
    /// Voir <see cref="IActionDataAccess"/>.
    /// </summary>
    public class ActionDataAccess : IActionDataAccess
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
        public ActionDataAccess(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Voir <see cref="IActionDataAccess.GetEntities(ActionRequestDto, List{string})"/>.
        /// </summary>
        public List<Action> GetEntities(ActionRequestDto requestDto, List<string> includes)
        {
            var xdoc = XDocument.Load(context.ActionXmlFile);
            var xmlEntities = xdoc.Root.Elements("action");

            // Récupération des entités.
            var entities = xmlEntities
                .Select(s => new Action
                {
                    Id = int.Parse(s.Attribute("id").Value),
                    IdActionDetail1 = int.Parse(s.Attribute("idActionDetail1").Value),
                    IdActionDetail2 = int.Parse(s.Attribute("idActionDetail2").Value),
                    IsActionEnabled = bool.Parse(s.Attribute("isActionEnabled").Value),
                })
                .Where(w => !requestDto.IsIdSpecified || (requestDto.IsIdSpecified && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsIsActionEnabledSpecified || (requestDto.IsIsActionEnabledSpecified && w.IsActionEnabled == requestDto.IsActionEnabled))
                .Where(w => !requestDto.IsIdActionDetail1Specified || (requestDto.IsIdActionDetail1Specified && w.IdActionDetail1 == requestDto.IdActionDetail1))
                .Where(w => !requestDto.IsIdActionDetail2Specified || (requestDto.IsIdActionDetail2Specified && w.IdActionDetail2 == requestDto.IdActionDetail2))
                .ToList();

            // Récupération des propriétés de navigation.
            if (includes.Any())
            {
                foreach (var entity in entities)
                {
                    if (includes.Any(w => (w.Equals("ActionDetail1") || w.EndsWith(".ActionDetail1"))))
                    {
                        entity.ActionDetail1 = ServiceLocator.Current.GetInstance<IActionDetailDataAccess>()
                            .GetEntity(entity.IdActionDetail1, includes.Where(w => !w.Equals("ActionDetail1") && w.Contains("ActionDetail1")).ToList());
                    }
                    if (includes.Any(w => (w.Equals("ActionDetail2") || w.EndsWith(".ActionDetail2"))))
                    {
                        entity.ActionDetail2 = ServiceLocator.Current.GetInstance<IActionDetailDataAccess>()
                            .GetEntity(entity.IdActionDetail1, includes.Where(w => !w.Equals("ActionDetail2") && w.Contains("ActionDetail2")).ToList());
                    }
                    if (includes.Any(w => (w.Equals("ExecutionActionList") || w.EndsWith(".ExecutionActionList"))))
                    {
                        var childRequestDto = new ExecutionActionRequestDto { IdAction = entity.Id, IsIdActionSpecified = true };
                        entity.ExecutionActionList = ServiceLocator.Current.GetInstance<IExecutionActionDataAccess>()
                            .GetEntities(childRequestDto, includes.Where(w => !w.Equals("ExecutionActionList") && w.Contains("ExecutionActionList")).ToList());
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// Voir <see cref="IActionDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        public Action GetEntity(int id, List<string> includes)
        {
            var requestDto = new ActionRequestDto
            {
                Id = id,
                IsIdSpecified = true
            };
            return GetEntities(requestDto, includes).FirstOrDefault();
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Voir <see cref="IActionDataAccess.InsertEntity(Action, BaseExecuteDto)"/>.
        /// </summary>
        public Action InsertEntity(Action entity, BaseExecuteDto executeDto)
        {
            var xdoc = XDocument.Load(context.ActionXmlFile);
            var i = int.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            entity.Id = i;
            xdoc.Root.Add(
                new XElement("action",
                new XAttribute("id", entity.Id),
                new XAttribute("idActionDetail1", entity.IdActionDetail1),
                new XAttribute("idActionDetail2", entity.IdActionDetail2),
                new XAttribute("isActionEnabled", entity.IsActionEnabled)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();
            xdoc.Save(context.ActionXmlFile);

            if (executeDto != null && executeDto.ReturnEntity)
            {
                return GetEntity(i, executeDto.Includes);
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IActionDataAccess.InsertEntities(List{Action}, BaseExecuteDto)"/>.
        /// </summary>
        public List<Action> InsertEntities(List<Action> entities, BaseExecuteDto executeDto)
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