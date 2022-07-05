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
    /// Classe de test de l’interface <see cref="ICategoryDataAccess"/>.
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
                // Création.

                // Préparation.
                Category entity = new("à récupérer");

                // Exécution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Récupération.

                // Préparation.
                var includes = new List<string>();
                var id = entity.Id;

                // Exécution.
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
                // Préparation.
                var includes = new List<string>();
                CategoryRequestDto requestDto = new()
                {
                    ProductId = 1,
                    IsSpecifiedProductId = true
                };

                // Exécution.
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
                // Préparation.
                IList<Category> entities = new List<Category>();
                Category entity1 = new("Catégorie 1");
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Category entity2 = new("Catégorie 2");
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Category entity3 = new("Catégorie 3");
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Exécution.
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
        [DataRow("Catégorie 1")]
        [DataRow("Catégorie 2")]
        [DataRow("Catégorie 3")]
        [DataRow("Catégorie 4")]
        [DataRow("Catégorie 5")]
        [DataRow("Catégorie 6")]
        [DataTestMethod]
        public void Create(string name)
        {
            try
            {
                // Préparation.
                Category entity = new(name);

                // Exécution.
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
                // Création.

                // Préparation.
                Category entity = new("à modifier");

                // Exécution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Modification.

                // Préparation.
                var name = "new catégorie";
                entity.Name = name;

                // Exécution.
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
                // Création.

                // Préparation.
                Category entity = new("à supprimer");

                // Exécution.
                entity = _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Create(entity, new CategoryExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Suppression.
                var id = entity.Id;

                // Exécution.
                _CategoryDataAccess.ExecuteMethod(() => _CategoryDataAccess.Delete(entity, new CategoryExecuteDto()));

                // ------------------------------
                // Récupération, pour voir si ça existe encore.

                // Exécution.
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