using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
    public class ElementDataAccess : BaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>, IElementDataAccess
    {
        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ElementDataAccess(MyFormationContext context)
            : base(context)
        {
        }

        #endregion

        #region Generic methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.ExecuteMethod(Action)"/>
        /// </summary>
        void IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.ExecuteMethod(Action action)
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
        /// Voir <see cref="IBaseDataAccess.ExecuteMethod{RT}(Expression{Func{RT}})(Action)"/>
        /// </summary>
        RT IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.ExecuteMethod<RT>(Expression<Func<RT>> expression)
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
        /// Voir <see cref="IBaseDataAccess.GetEntityXml(int, List{string})"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntityXml(int id, List<string> includes)
        {
            var requestDto = new ElementRequestDto
            {
                Id = id,
                IsSpecifiedId = true
            };
            return (this as IElementDataAccess).GetEntitiesXml(requestDto, includes).FirstOrDefault();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntity(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Elements.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? queryable.AsNoTracking().FirstOrDefault() : queryable.FirstOrDefault();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntityAsync(int, List{string}, bool)"/>.
        /// </summary>
        async Task<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntityAsync(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Elements.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? await queryable.AsNoTracking().FirstOrDefaultAsync() : await queryable.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesXml(R, List{string})"/>.
        /// </summary>
        IEnumerable<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntitiesXml(ElementRequestDto requestDto, List<string> includes)
        {
            XDocument = XDocument.Load(StoreFile);

            var Elements = XDocument.Root.Elements("Element");
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

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntities(R, List{string}, bool)/>.
        /// </summary>
        IEnumerable<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntities(ElementRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Elements.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedDescription || (requestDto.IsSpecifiedDescription && w.Description == requestDto.Description))
                .Where(w => !requestDto.IsSpecifiedDueDate || (requestDto.IsSpecifiedDueDate && w.DueDate == requestDto.DueDate))
                .Where(w => !requestDto.IsSpecifiedResolutionPercent || (requestDto.IsSpecifiedResolutionPercent && w.ResolutionPercent == requestDto.ResolutionPercent))
                .Where(w => !requestDto.IsSpecifiedIsReminder || (requestDto.IsSpecifiedIsReminder && w.IsReminder == requestDto.IsReminder))
                .Where(w => !requestDto.IsSpecifiedIsFavorite || (requestDto.IsSpecifiedIsFavorite && w.IsFavorite == requestDto.IsFavorite))
                .Where(w => !requestDto.IsSpecifiedIsClosed || (requestDto.IsSpecifiedIsClosed && w.IsClosed == requestDto.IsClosed));

            return asNoTracking ? queryable.AsNoTracking().ToList() : queryable.ToList();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesAsync(R, List{string}, bool)/>.
        /// </summary>
        async Task<IEnumerable<Element>> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.GetEntitiesAsync(ElementRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Elements.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedDescription || (requestDto.IsSpecifiedDescription && w.Description == requestDto.Description))
                .Where(w => !requestDto.IsSpecifiedDueDate || (requestDto.IsSpecifiedDueDate && w.DueDate == requestDto.DueDate))
                .Where(w => !requestDto.IsSpecifiedResolutionPercent || (requestDto.IsSpecifiedResolutionPercent && w.ResolutionPercent == requestDto.ResolutionPercent))
                .Where(w => !requestDto.IsSpecifiedIsReminder || (requestDto.IsSpecifiedIsReminder && w.IsReminder == requestDto.IsReminder))
                .Where(w => !requestDto.IsSpecifiedIsFavorite || (requestDto.IsSpecifiedIsFavorite && w.IsFavorite == requestDto.IsFavorite))
                .Where(w => !requestDto.IsSpecifiedIsClosed || (requestDto.IsSpecifiedIsClosed && w.IsClosed == requestDto.IsClosed));

            return asNoTracking ? await queryable.AsNoTracking().ToListAsync() : await queryable.ToListAsync();
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.SaveXml(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.SaveXml(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            XDocument = XDocument.Load(StoreFile);

            // Insertion, modification et suppression.
            IList<Element> returnEntities = new List<Element>();
            foreach (Element Element in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Element.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ElementAdded = (this as IElementDataAccess).CreateXml(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ElementModified = (this as IElementDataAccess).UpdateXml(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        (this as IElementDataAccess).DeleteXml(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                XDocument.Save(StoreFile);

                if (executeDto.IsReturnEntityEnabled)
                {
                    ElementRequestDto requestDto = new ElementRequestDto
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return (this as IElementDataAccess).GetEntitiesXml(requestDto, executeDto.Includes);
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Save(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.Save(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Element> returnEntities = new List<Element>();
            foreach (Element Element in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Element.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ElementAdded = (this as IElementDataAccess).Create(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ElementModified = (this as IElementDataAccess).Update(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        (this as IElementDataAccess).Delete(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();

                if (executeDto.IsReturnEntityEnabled)
                {
                    ElementRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return (this as IElementDataAccess).GetEntities(requestDto, executeDto.Includes, executeDto.AsNoTracking);
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.SaveAsync(IEnumerable{T}, E)"/>.
        /// </summary>
        async Task<IEnumerable<Element>> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.SaveAsync(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Element> returnEntities = new List<Element>();
            foreach (Element Element in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Element.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ElementAdded = await (this as IElementDataAccess).CreateAsync(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ElementModified = await (this as IElementDataAccess).UpdateAsync(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ElementModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        await (this as IElementDataAccess).DeleteAsync(Element, new ElementExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();

                if (executeDto.IsReturnEntityEnabled)
                {
                    ElementRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return await (this as IElementDataAccess).GetEntitiesAsync(requestDto, executeDto.Includes, executeDto.AsNoTracking);
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.CreateXml(T, E)"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.CreateXml(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (XDocument == null)
                XDocument = XDocument.Load(StoreFile);

            // Modification du fichier xml.
            entity.Id = int.Parse(XDocument.Root.Attribute("autoincrement").Value) + 1;
            XDocument.Root.Add(new XElement("Element",
                new XAttribute("id", entity.Id),
                new XAttribute("name", entity.Name ?? string.Empty),
                new XAttribute("description", entity.Description ?? string.Empty),
                new XAttribute("resolutionPercent", entity.ResolutionPercent),
                new XAttribute("dueDate", entity.DueDate.GetValueOrDefault().ToShortDateString()),
                new XAttribute("isReminder", entity.IsReminder),
                new XAttribute("isClosed", entity.IsClosed),
                new XAttribute("isFavorite", entity.IsFavorite)));
            XDocument.Root.Attribute("autoincrement").Value = entity.Id.ToString();

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                XDocument.Save(StoreFile);
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntityXml(entity.Id, executeDto.Includes) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Create(T, E)"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.Create(Element entity, ElementExecuteDto executeDto)
        {
            Context.Set<Element>().Add(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                try
                {
                    Context.SaveChanges();

                }
                catch (Exception ex)
                {
                    
                }
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.CreateAsync(T, E)"/>.
        /// </summary>
        async Task<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.CreateAsync(Element entity, ElementExecuteDto executeDto)
        {
            await Context.Set<Element>().AddAsync(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as IElementDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateXml(T, E)"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.UpdateXml(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (XDocument == null)
                XDocument = XDocument.Load(StoreFile);

            // Modification du fichier xml.
            XElement Element = XDocument.Descendants("Element").FirstOrDefault(w => int.Parse(w.Attribute("id").Value) == entity.Id);
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
                XDocument.Save(StoreFile);
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntityXml(entity.Id, executeDto.Includes) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Update(T, E)"/>.
        /// </summary>
        Element IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.Update(Element entity, ElementExecuteDto executeDto)
        {
            Context.Set<Element>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();
                return executeDto.IsReturnEntityEnabled ? (this as IElementDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;

        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateAsync(T, E)"/>.
        /// </summary>
        async Task<Element> IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.UpdateAsync(Element entity, ElementExecuteDto executeDto)
        {
            Context.Set<Element>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as IElementDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteXml(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.DeleteXml(Element entity, ElementExecuteDto executeDto)
        {
            // Ouverture du fichier xml.
            if (XDocument == null)
                XDocument = XDocument.Load(StoreFile);

            // Modification du fichier xml.
            XDocument.Descendants("Element")
                .Where(w => int.Parse(w.Attribute("id").Value) == entity.Id)
                .Remove();

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                XDocument.Save(StoreFile);
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Delete(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.Delete(Element entity, ElementExecuteDto executeDto)
        {
            Context.Set<Element>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                Context.SaveChanges();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteAsync(T, E)"/>.
        /// </summary>
        async Task IBaseDataAccess<Element, ElementRequestDto, ElementExecuteDto>.DeleteAsync(Element entity, ElementExecuteDto executeDto)
        {
            Context.Set<Element>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                await Context.SaveChangesAsync();
        }

        #endregion
    }
}
