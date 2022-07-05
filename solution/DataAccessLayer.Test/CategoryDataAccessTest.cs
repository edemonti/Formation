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
    /// Classe de test de l�interface <see cref="ICategoryDataAccess"/>.
    /// </summary>
    [TestClass]
    public class CategoryDataAccessTest : BaseTest
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="IDataAccessBase"/>.
        /// </summary>
        private readonly ICategoryDataAccess _CategoryDataAccess;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public CategoryDataAccessTest()
            : base("DefaultConnectionString")
        {
            _CategoryDataAccess = new CategoryDataAccess(base.Context);
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
                Category entity = new("� r�cup�rer");

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // R�cup�ration.

                // Pr�paration.
                var includes = new List<string>();
                var id = entity.Id;

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.GetEntity(id, includes, false));

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
                CategoryRequestDto requestDto = new()
                {
                    ProductId = 1,
                    IsSpecifiedProductId = true
                };

                // Ex�cution.
                IEnumerable<Category> entities = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.GetEntities(requestDto, includes, false));

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
                IList<Category> entities = new List<Category>();
                Category entity1 = new("Cat�gorie 1");
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Category entity2 = new("Cat�gorie 2");
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Category entity3 = new("Cat�gorie 3");
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Ex�cution.
                entities = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Save(entities, new CategoryExecuteDto())).ToList();

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
        [DataRow("Cat�gorie 1")]
        [DataRow("Cat�gorie 2")]
        [DataRow("Cat�gorie 3")]
        [DataRow("Cat�gorie 4")]
        [DataRow("Cat�gorie 5")]
        [DataRow("Cat�gorie 6")]
        [DataTestMethod]
        public void Create(string name)
        {
            try
            {
                // Pr�paration.
                Category entity = new(name);

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.Update(T, E)"/>.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Category entity = new("� modifier");

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Modification.

                // Pr�paration.
                var name = "new cat�gorie";
                entity.Name = name;

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Update(entity, new CategoryExecuteDto()));

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
                Category entity = new("� supprimer");

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Suppression.
                var id = entity.Id;

                // Ex�cution.
                _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Delete(entity, new CategoryExecuteDto()));

                // ------------------------------
                // R�cup�ration, pour voir si �a existe encore.

                // Ex�cution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.GetEntity(id, new List<string>(), false));

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