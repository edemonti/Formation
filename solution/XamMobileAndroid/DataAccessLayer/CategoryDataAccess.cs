using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
    /// Voir <see cref="ICategoryDataAccess"/>.
    /// </summary>
    public class CategoryDataAccess : BaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>, ICategoryDataAccess
    {
        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public CategoryDataAccess(MyFormationContext context)
            : base(context)
        {
        }

        #endregion

        #region Generic methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.ExecuteMethod(Action)"/>
        /// </summary>
        void IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.ExecuteMethod(Action action)
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
        RT IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.ExecuteMethod<RT>(Expression<Func<RT>> expression)
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
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntityXml(int id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntity(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Categories.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? queryable.AsNoTracking().FirstOrDefault() : queryable.FirstOrDefault();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntityAsync(int, List{string}, bool)"/>.
        /// </summary>
        async Task<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntityAsync(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Categories.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? await queryable.AsNoTracking().FirstOrDefaultAsync() : await queryable.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesXml(R, List{string})"/>.
        /// </summary>
        IEnumerable<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntitiesXml(CategoryRequestDto requestDto, List<string> includes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntities(R, List{string}, bool)"/>.
        /// </summary>
        IEnumerable<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntities(CategoryRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Categories.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedProductId || (requestDto.IsSpecifiedProductId && w.Products.Any(a => a.Id == requestDto.ProductId)));

            return asNoTracking ? queryable.AsNoTracking().ToList() : queryable.ToList();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesAsync(R, List{string}, bool)"/>.
        /// </summary>
        async Task<IEnumerable<Category>> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.GetEntitiesAsync(CategoryRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Categories.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedProductId || (requestDto.IsSpecifiedProductId && w.Products.Any(a => a.Id == requestDto.ProductId)));

            return asNoTracking ? await queryable.AsNoTracking().ToListAsync() : await queryable.ToListAsync();
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.SaveXml(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.SaveXml(IEnumerable<Category> entities, CategoryExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Save(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.Save(IEnumerable<Category> entities, CategoryExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Category> returnEntities = new List<Category>();
            foreach (Category Category in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Category.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var CategoryAdded = (this as ICategoryDataAccess).Create(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(CategoryAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var CategoryModified = (this as ICategoryDataAccess).Update(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(CategoryModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        (this as ICategoryDataAccess).Delete(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();

                if (executeDto.IsReturnEntityEnabled)
                {
                    CategoryRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return (this as ICategoryDataAccess).GetEntities(requestDto, executeDto.Includes, executeDto.AsNoTracking);
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
        async Task<IEnumerable<Category>> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.SaveAsync(IEnumerable<Category> entities, CategoryExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Category> returnEntities = new List<Category>();
            foreach (Category Category in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Category.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var CategoryAdded = await (this as ICategoryDataAccess).CreateAsync(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(CategoryAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var CategoryModified = await (this as ICategoryDataAccess).UpdateAsync(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(CategoryModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        await (this as ICategoryDataAccess).DeleteAsync(Category, new CategoryExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();

                if (executeDto.IsReturnEntityEnabled)
                {
                    CategoryRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return await (this as ICategoryDataAccess).GetEntitiesAsync(requestDto, executeDto.Includes, executeDto.AsNoTracking);
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
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.CreateXml(Category entity, CategoryExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Create(T, E)"/>.
        /// </summary>
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.Create(Category entity, CategoryExecuteDto executeDto)
        {
            Context.Set<Category>().Add(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();
                return executeDto.IsReturnEntityEnabled ? (this as ICategoryDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.CreateAsync(T, E)"/>.
        /// </summary>
        async Task<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.CreateAsync(Category entity, CategoryExecuteDto executeDto)
        {
            await Context.Set<Category>().AddAsync(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as ICategoryDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateXml(T, E)"/>.
        /// </summary>
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.UpdateXml(Category entity, CategoryExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Update(T, E)"/>.
        /// </summary>
        Category IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.Update(Category entity, CategoryExecuteDto executeDto)
        {
            Context.Set<Category>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();
                return executeDto.IsReturnEntityEnabled ? (this as ICategoryDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;

        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateAsync(T, E)"/>.
        /// </summary>
        async Task<Category> IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.UpdateAsync(Category entity, CategoryExecuteDto executeDto)
        {
            Context.Set<Category>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as ICategoryDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteXml(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.DeleteXml(Category entity, CategoryExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Delete(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.Delete(Category entity, CategoryExecuteDto executeDto)
        {
            Context.Set<Category>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                Context.SaveChanges();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteAsync(T, E)"/>.
        /// </summary>
        async Task IBaseDataAccess<Category, CategoryRequestDto, CategoryExecuteDto>.DeleteAsync(Category entity, CategoryExecuteDto executeDto)
        {
            Context.Set<Category>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                await Context.SaveChangesAsync();
        }

        #endregion
    }
}
