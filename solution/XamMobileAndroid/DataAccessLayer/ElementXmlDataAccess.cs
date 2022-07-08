using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using DataAccessLayer.Interface;
using EntityFrameworkLayer.Context;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Microsoft.EntityFrameworkCore;
using Technical.Exceptions;

namespace DataAccessLayer
{
    /// <summary>
    /// Voir <see cref="IElementDataAccess"/>.
    /// </summary>
    public class ElementDataAccess : IElementDataAccess
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="MyFormationContext"/>.
        /// </summary>
        private readonly MyFormationContext _context;

        /// <summary>
        /// Fichier xml contenant la liste des tâches.
        /// </summary>
        private readonly string _storeFile;

        /// <summary>
        /// Document Xml contenant la liste des tâches.
        /// </summary>
        private XDocument _xDocument;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ElementDataAccess(MyFormationContext context)
        {
            _context = context;
            _storeFile = $@"{_context.Database.GetDbConnection().ConnectionString}Element.xml";
        }

        #endregion

        #region Generic methods

        /// <summary>
        /// Voir <see cref="IElementDataAccess.ExecuteMethod(Action)"/>
        /// </summary>
        void IElementDataAccess.ExecuteMethod(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Voir <see cref="IElementDataAccess.ExecuteMethod{R}(Expression{Func{R}})"/>
        /// </summary>
        R IElementDataAccess.ExecuteMethod<R>(Expression<Func<R>> expression)
        {
            try
            {
                return expression.Compile().Invoke();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
        }

        #endregion

        #region Reading methods

        /// <summary>
        /// Voir <see cref="IElementDataAccess.GetEntity"/>.
        /// </summary>
        Element IElementDataAccess.GetEntity(int id, List<string> includes)
        {
            var requestDto = new ElementRequestDto
            {
                Id = id,
                IsSpecifiedId = true
            };
            return (this as IElementDataAccess).GetEntities(requestDto, includes).FirstOrDefault();
        }

        /// <summary>
        /// Voir <see cref="IElementDataAccess.GetEntities"/>.
        /// </summary>
        IEnumerable<Element> IElementDataAccess.GetEntities(ElementRequestDto requestDto, List<string> includes)
        {
            _xDocument = XDocument.Load(_storeFile);

            var Elements = _xDocument.Root.Elements("Element");
            return Elements
                .Select(s =>
                    new Element(
                        int.Parse(s.Attribute("id").Value),
                         s.Attribute("name").Value,
                        s.Attribute("description").Value,
                        DateTime.Parse(s.Attribute("dueDate").Value),
                        int.Parse(s.Attribute("id").Value),
                        bool.Parse(s.Attribute("isReminder").Value),
                        bool.Parse(s.Attribute("isClosed").Value),
                        bool.Parse(s.Attribute("isFavorite").Value)))
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedDescription || (requestDto.IsSpecifiedDescription && w.Description == requestDto.Description))
                .Where(w => !requestDto.IsSpecifiedDueDate || (requestDto.IsSpecifiedDueDate && w.DueDate == requestDto.DueDate))
                .Where(w => !requestDto.IsSpecifiedResolutionPercent || (requestDto.IsSpecifiedResolutionPercent && w.ResolutionPercent == requestDto.ResolutionPercent))
                .Where(w => !requestDto.IsSpecifiedIsReminder || (requestDto.IsSpecifiedIsReminder && w.IsReminder == requestDto.IsReminder))
                .Where(w => !requestDto.IsSpecifiedIsFavorite || (requestDto.IsSpecifiedIsFavorite && w.IsFavorite == requestDto.IsFavorite))
                .Where(w => !requestDto.IsSpecifiedIsClosed || (requestDto.IsSpecifiedIsClosed && w.IsClosed == requestDto.IsClosed))
                .ToList();
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IElementDataAccess.SaveEntities"/>.
        /// </summary>
        IEnumerable<Element> IElementDataAccess.SaveEntities(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            _xDocument = XDocument.Load(_storeFile);

            // Insertion, modification et suppresion.
            IList<Element> returnEntities = new List<Element>();
            foreach (Element Element in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Element.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ElementAdded = (this as IElementDataAccess).InsertEntity(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ElementModified = (this as IElementDataAccess).UpdateEntity(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        (this as IElementDataAccess).DeleteEntity(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                _xDocument.Save(_storeFile);

                if (executeDto.IsReturnEntityEnabled)
                {
                    ElementRequestDto requestDto = new ElementRequestDto
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return (this as IElementDataAccess).GetEntities(requestDto, executeDto.Includes);
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IElementDataAccess.InsertEntity"/>.
        /// </summary>
        Element IElementDataAccess.InsertEntity(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (_xDocument == null)
                _xDocument = XDocument.Load(_storeFile);

            // Modification du fichier xml.
            entity.Id = int.Parse(_xDocument.Root.Attribute("autoincrement").Value) + 1;
            _xDocument.Root.Add(new XElement("Element",
                new XAttribute("id", entity.Id),
                new XAttribute("name", entity.Name ?? string.Empty),
                new XAttribute("description", entity.Description ?? string.Empty),
                new XAttribute("resolutionPercent", entity.ResolutionPercent),
                new XAttribute("dueDate", entity.DueDate.GetValueOrDefault().ToShortDateString()),
                new XAttribute("isReminder", entity.IsReminder),
                new XAttribute("isClosed", entity.IsClosed),
                new XAttribute("isFavorite", entity.IsFavorite)));
            _xDocument.Root.Attribute("autoincrement").Value = entity.Id.ToString();

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                _xDocument.Save(_storeFile);
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntity(entity.Id, executeDto.Includes) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IElementDataAccess.UpdateEntity"/>.
        /// </summary>
        Element IElementDataAccess.UpdateEntity(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (_xDocument == null)
                _xDocument = XDocument.Load(_storeFile);

            // Modification du fichier xml.
            XElement Element = _xDocument.Descendants("Element").FirstOrDefault(w => int.Parse(w.Attribute("id").Value) == entity.Id);
            Element.Attribute("id").Value = entity.Id.ToString();
            Element.Attribute("name").Value = entity.Name;
            Element.Attribute("description").Value = entity.Description.ToString();
            Element.Attribute("resolutionPercent").Value = entity.ResolutionPercent.ToString();
            Element.Attribute("dueDate").Value = entity.DueDate.GetValueOrDefault().ToShortDateString();
            Element.Attribute("isReminder").Value = entity.IsReminder.ToString();
            Element.Attribute("isClosed").Value = entity.IsClosed.ToString();
            Element.Attribute("isFavorite").Value = entity.IsFavorite.ToString();

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                _xDocument.Save(_storeFile);
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntity(entity.Id, executeDto.Includes) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IElementDataAccess.DeleteEntity"/>.
        /// </summary>
        void IElementDataAccess.DeleteEntity(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (_xDocument == null)
                _xDocument = XDocument.Load(_storeFile);

            // Modification du fichier xml.
            _xDocument.Descendants("Element")
                .Where(w => int.Parse(w.Attribute("id").Value) == entity.Id)
                .Remove();

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                _xDocument.Save(_storeFile);
        }

        #endregion
    }
}
