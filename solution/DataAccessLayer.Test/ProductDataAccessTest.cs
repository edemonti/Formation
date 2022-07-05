using DataAccessLayer.Interface;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Technical.Exceptions;
using Technical.Test;

namespace DataAccessLayer.Test
{
    /// <summary>
    /// Classe de test de l�interface <see cref="IProductDataAccess"/>.
    /// </summary>
    [TestClass]
    public class ProductDataAccessTest : BaseTest
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="IDataAccessBase"/>.
        /// </summary>
        private readonly IProductDataAccess _ProductDataAccess;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ProductDataAccessTest()
            : base("DefaultConnectionString")
        {
            _ProductDataAccess = new ProductDataAccess(base.Context);
        }

        #endregion

        #region Reading methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.GetEntity"/>.
        /// </summary>
        [TestMethod]
        public void GetEntity()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Product entity = new("� r�cup�rer", 10, 1);

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Create(entity, new ProductExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // R�cup�ration.

                // Pr�paration.
                var includes = new List<string>();
                var id = entity.Id;

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.GetEntity(id, includes, false));

                // Assert.
                Assert.IsNotNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.GetEntities"/>.
        /// </summary>
        [TestMethod]
        public void GetEntities()
        {
            try
            {
                // Pr�paration.
                var includes = new List<string>();
                ProductRequestDto requestDto = new()
                {
                    Quantity = 10,
                    IsSpecifiedQuantity = true
                };

                // Ex�cution.
                IEnumerable<Product> entities = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.GetEntities(requestDto, includes, false));

                // Assert.
                Assert.IsNotNull(entities);
                Assert.AreNotEqual(0, entities.Count());
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.Save"/>.
        /// </summary>
        [TestMethod]
        public void SaveEntities()
        {
            try
            {
                // Pr�paration.
                IList<Product> entities = new List<Product>();
                Product entity1 = new("Produit 1", 10, 1);
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Product entity2 = new("Produit 2", 10, 1);
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Product entity3 = new("Produit 3", 10, 1);
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Ex�cution.
                entities = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Save(entities, new ProductExecuteDto())).ToList();

                // Assert.
                Assert.IsNotNull(entities);
                Assert.AreNotEqual(0, entities.Count);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.Create"/>.
        /// </summary>
        [DataRow("Produit 1", 1, 1)]
        [DataRow("Produit 2", 10, 1)]
        [DataRow("Produit 3", 22, 1)]
        [DataRow("Produit 4", 55, 1)]
        [DataRow("Produit 5", 12, 1)]
        [DataRow("Produit 6", 8, 1)]
        [DataTestMethod]
        public void Create(string name, int quantity, int categoryId)
        {
            try
            {
                // Pr�paration.
                Product entity = new(name, quantity, categoryId);

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Create(entity, new ProductExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.Update"/>.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Product entity = new("� modifier", 10, 1);

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Create(entity, new ProductExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Modification.

                // Pr�paration.
                var name = "new produit";
                entity.Name = name;

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Update(entity, new ProductExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);
                Assert.AreEqual(entity.Name, name);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.Delete"/>.
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Product entity = new("� supprimer", 10, 1);

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Create(entity, new ProductExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Suppression.
                var id = entity.Id;

                // Ex�cution.
                _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.Delete(entity, new ProductExecuteDto()));

                // ------------------------------
                // R�cup�ration, pour voir si �a existe encore.

                // Ex�cution.
                entity = _ProductDataAccess.ExecuteMethod(() => _ProductDataAccess.GetEntity(id, new List<string>(), false));

                // Assert.
                Assert.IsNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion
    }
}