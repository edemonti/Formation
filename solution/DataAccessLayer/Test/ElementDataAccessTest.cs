using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Technical.Exceptions;

namespace DataAccessLayer.Test
{
    /// <summary>
    /// Classe de test de l�interface <see cref="IElementDataAccess"/>.
    /// </summary>
    [TestClass]
    public class ElementDataAccessTest : BaseTest
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="IDataAccessBase"/>.
        /// </summary>
        private readonly IElementDataAccess _elementDataAccess;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ElementDataAccessTest()
            : base("DefaultConnectionString")
        {
            _elementDataAccess = new ElementDataAccess(base.Context);
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
                Element entity = new(0, "new", string.Empty, null, 0, false, false, false);

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // R�cup�ration.

                // Pr�paration.
                var includes = new List<string>();
                var id = entity.Id;

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntity(id, includes, false));

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
                ElementRequestDto requestDto = new()
                {
                    IsFavorite = false,
                    IsSpecifiedIsFavorite = true
                };

                // Ex�cution.
                IEnumerable<Element> entities = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntities(requestDto, includes, false));

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
                IList<Element> entities = new List<Element>();
                Element entity1 = new(0, "T�che 1");
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Element entity2 = new(0, "T�che 2");
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Element entity3 = new(0, "T�che 3");
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Ex�cution.
                entities = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Save(entities, new ElementExecuteDto())).ToList();

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
        [DataRow("T�che 1", "Description", "01/01/2022", 3, false, false, false)]
        [DataRow("T�che 2", "Description", "01/02/2022", 75, false, false, true)]
        [DataRow("T�che 3", "Description", "01/03/2022", 100, true, false, true)]
        [DataRow("T�che 4", "Description", "01/04/2022", 0, false, true, false)]
        [DataRow("T�che 5", "Description", "01/05/2022", 0, true, false, false)]
        [DataRow("T�che 6", "Description", "01/06/2022", 30, true, false, false)]
        [DataTestMethod]
        public void Create(string name, string description, string dueDate, int resolutionPercent, bool isReminder, bool isFavorite, bool isClosed)
        {
            try
            {
                // Pr�paration.
                Element entity = new(0, name, description, DateTime.Parse(dueDate), resolutionPercent, isReminder, isFavorite, isClosed);

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Create(entity, new ElementExecuteDto()));

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
        public void UpdateEntity()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Element entity = new(0, "� modifier", string.Empty, null, 0, false, false, false);

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Modification.

                // Pr�paration.
                var description = "new description";
                entity.Description = description;

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Update(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);
                Assert.AreEqual(entity.Description, description);
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
        public void DeleteEntity()
        {
            try
            {
                // ------------------------------
                // Cr�ation.

                // Pr�paration.
                Element entity = new(0, "� supprimer", string.Empty, null, 0, false, false, false);

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Suppression.
                var id = entity.Id;

                // Ex�cution.
                _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Delete(entity, new ElementExecuteDto()));

                // ------------------------------
                // R�cup�ration, pour voir si �a existe encore.

                // Ex�cution.
                entity = _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntity(id, new List<string>(), false));

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