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
    /// Voir <see cref="IProductDataAccess"/>.
    /// </summary>
    public class ProductDataAccess : BaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>, IProductDataAccess
    {
        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ProductDataAccess(MyFormationContext context)
            : base(context)
        {
        }

        #endregion

        #region Generic methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.ExecuteMethod(Action)"/>
        /// </summary>
        void IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.ExecuteMethod(Action action)
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
        RT IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.ExecuteMethod<RT>(Expression<Func<RT>> expression)
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
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntityXml(int id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntity(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Products.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? queryable.AsNoTracking().FirstOrDefault() : queryable.FirstOrDefault();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntityAsync(int, List{string}, bool)"/>.
        /// </summary>
        async Task<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntityAsync(int id, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Products.AsQueryable()
                .Where(w => w.Id == id);

            return asNoTracking ? await queryable.AsNoTracking().FirstOrDefaultAsync() : await queryable.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesXml(R, List{string})"/>.
        /// </summary>
        IEnumerable<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntitiesXml(ProductRequestDto requestDto, List<string> includes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntities(R, List{string}, bool)"/>.
        /// </summary>
        IEnumerable<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntities(ProductRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Products.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedQuantity || (requestDto.IsSpecifiedQuantity && w.Quantity == requestDto.Quantity))
                .Where(w => !requestDto.IsSpecifiedCategoryId || (requestDto.IsSpecifiedCategoryId && w.CategoryId == requestDto.CategoryId));

            return asNoTracking ? queryable.AsNoTracking().ToList() : queryable.ToList();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.GetEntitiesAsync(R, List{string}, bool)"/>.
        /// </summary>
        async Task<IEnumerable<Product>> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.GetEntitiesAsync(ProductRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            var queryable = Context.Products.AsQueryable()
                .Where(w => !requestDto.IsSpecifiedId || (requestDto.IsSpecifiedId && w.Id == requestDto.Id))
                .Where(w => !requestDto.IsSpecifiedIdList || (requestDto.IsSpecifiedIdList && requestDto.IdList.Contains(w.Id)))
                .Where(w => !requestDto.IsSpecifiedName || (requestDto.IsSpecifiedName && w.Name == requestDto.Name))
                .Where(w => !requestDto.IsSpecifiedQuantity || (requestDto.IsSpecifiedQuantity && w.Quantity == requestDto.Quantity))
                .Where(w => !requestDto.IsSpecifiedCategoryId || (requestDto.IsSpecifiedCategoryId && w.CategoryId == requestDto.CategoryId));

            return asNoTracking ? await queryable.AsNoTracking().ToListAsync() : await queryable.ToListAsync();
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.SaveXml(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.SaveXml(IEnumerable<Product> entities, ProductExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Save(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.Save(IEnumerable<Product> entities, ProductExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Product> returnEntities = new List<Product>();
            foreach (Product Product in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Product.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ProductAdded = (this as IProductDataAccess).Create(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ProductAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ProductModified = (this as IProductDataAccess).Update(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ProductModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        (this as IProductDataAccess).Delete(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();

                if (executeDto.IsReturnEntityEnabled)
                {
                    ProductRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return (this as IProductDataAccess).GetEntities(requestDto, executeDto.Includes, executeDto.AsNoTracking);
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
        async Task<IEnumerable<Product>> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.SaveAsync(IEnumerable<Product> entities, ProductExecuteDto executeDto)
        {
            // Insertion, modification et suppression.
            IList<Product> returnEntities = new List<Product>();
            foreach (Product Product in entities.Where(w => w.State != EntityState.Unchanged))
            {
                switch (Product.State)
                {
                    // Insertion.
                    case EntityState.Added:
                        var ProductAdded = await (this as IProductDataAccess).CreateAsync(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ProductAdded);
                        break;
                    // Modification.
                    case EntityState.Modified:
                        var ProductModified = await (this as IProductDataAccess).UpdateAsync(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        if (executeDto.IsReturnEntityEnabled)
                            returnEntities.Add(ProductModified);
                        break;
                    // Suppression.
                    case EntityState.Deleted:
                        await (this as IProductDataAccess).DeleteAsync(Product, new ProductExecuteDto(executeDto.IsReturnEntityEnabled, false, executeDto.Includes));
                        break;
                }
            }

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();

                if (executeDto.IsReturnEntityEnabled)
                {
                    ProductRequestDto requestDto = new()
                    {
                        IsSpecifiedIdList = true,
                        IdList = returnEntities.Select(s => s.Id).ToList()
                    };
                    return await (this as IProductDataAccess).GetEntitiesAsync(requestDto, executeDto.Includes, executeDto.AsNoTracking);
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
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.CreateXml(Product entity, ProductExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Create(T, E)"/>.
        /// </summary>
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.Create(Product entity, ProductExecuteDto executeDto)
        {
            Context.Set<Product>().Add(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();
                return executeDto.IsReturnEntityEnabled ? (this as IProductDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.CreateAsync(T, E)"/>.
        /// </summary>
        async Task<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.CreateAsync(Product entity, ProductExecuteDto executeDto)
        {
            await Context.Set<Product>().AddAsync(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as IProductDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateXml(T, E)"/>.
        /// </summary>
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.UpdateXml(Product entity, ProductExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Update(T, E)"/>.
        /// </summary>
        Product IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.Update(Product entity, ProductExecuteDto executeDto)
        {
            Context.Set<Product>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                Context.SaveChanges();
                return executeDto.IsReturnEntityEnabled ? (this as IProductDataAccess).GetEntity(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;

        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.UpdateAsync(T, E)"/>.
        /// </summary>
        async Task<Product> IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.UpdateAsync(Product entity, ProductExecuteDto executeDto)
        {
            Context.Set<Product>().Update(entity);

            // Sauvegarde et récupération de l’entité.
            if (executeDto.IsSaveEnabled)
            {
                await Context.SaveChangesAsync();
                return executeDto.IsReturnEntityEnabled ? await (this as IProductDataAccess)
                    .GetEntityAsync(entity.Id, executeDto.Includes, executeDto.AsNoTracking) : null;
            }
            else
                return executeDto.IsReturnEntityEnabled ? entity : null;
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteXml(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.DeleteXml(Product entity, ProductExecuteDto executeDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.Delete(T, E)"/>.
        /// </summary>
        void IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.Delete(Product entity, ProductExecuteDto executeDto)
        {
            Context.Set<Product>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                Context.SaveChanges();
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess.DeleteAsync(T, E)"/>.
        /// </summary>
        async Task IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>.DeleteAsync(Product entity, ProductExecuteDto executeDto)
        {
            Context.Set<Product>().Remove(entity);

            // Sauvegarde.
            if (executeDto.IsSaveEnabled)
                await Context.SaveChangesAsync();
        }

        #endregion
    }
}
