using BusinessLogicalLayer.Interface;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Technical.Exceptions;
using Technical.Test;

namespace BusinessLogicalLayer.Test
{
    /// <summary>
    /// Classe de test de l’interface <see cref="IElementBusinessLogical"/>.
    /// </summary>
    [TestClass]
    public class ElementBusinessLogicalTest : BaseTest
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="IElementBusinessLogical"/>.
        /// </summary>
        private readonly IElementBusinessLogical _elementBusinessLogical;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ElementBusinessLogicalTest()
            : base("DefaultConnectionString")
        {
            _elementBusinessLogical = new ElementBusinessLogical(base.Context);
        }

        #endregion

        #region Reading methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.GetEntity"/>.
        /// </summary>
        [TestMethod]
        public void GetEntity()
        {
            try
            {
                // ------------------------------
                // Création.

                // Préparation.
                Element entity = new(0, "new", string.Empty, null, 0, false, false, false);

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Récupération.

                // Préparation.
                var includes = new List<string>();
                var id = entity.Id;

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.GetEntity(id, includes, false));

                // Assert.
                Assert.IsNotNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.GetEntities"/>.
        /// </summary>
        [TestMethod]
        public void GetEntities()
        {
            try
            {
                // Préparation.
                var includes = new List<string>();
                ElementRequestDto requestDto = new()
                {
                    IsFavorite = false,
                    IsSpecifiedIsFavorite = true
                };

                // Exécution.
                IEnumerable<Element> entities = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.GetEntities(requestDto, includes, false));

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
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.Save"/>.
        /// </summary>
        [TestMethod]
        public void SaveEntities()
        {
            try
            {
                // Préparation.
                IList<Element> entities = new List<Element>();
                Element entity1 = new(0, "Tâche 1");
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Element entity2 = new(0, "Tâche 2");
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Element entity3 = new(0, "Tâche 3");
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Exécution.
                entities = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Save(entities, new ElementExecuteDto())).ToList();

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
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.Create"/>.
        /// </summary>
        [DataRow("Tâche 1", "Description", "01/01/2022", 3, false, false, false)]
        [DataRow("Tâche 2", "Description", "01/02/2022", 75, false, false, true)]
        [DataRow("Tâche 3", "Description", "01/03/2022", 100, true, false, true)]
        [DataRow("Tâche 4", "Description", "01/04/2022", 0, false, true, false)]
        [DataRow("Tâche 5", "Description", "01/05/2022", 0, true, false, false)]
        [DataRow("Tâche 6", "Description", "01/06/2022", 30, true, false, false)]
        [DataTestMethod]
        public void Create(string name, string description, string dueDate, int resolutionPercent, bool isReminder, bool isFavorite, bool isClosed)
        {
            try
            {
                // Préparation.
                Element entity = new(0, name, description, DateTime.Parse(dueDate), resolutionPercent, isReminder, isFavorite, isClosed);

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.Update(T, E)"/>.
        /// </summary>
        [TestMethod]
        public void UpdateEntity()
        {
            try
            {
                // ------------------------------
                // Création.

                // Préparation.
                Element entity = new(0, "à modifier", string.Empty, null, 0, false, false, false);

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Modification.

                // Préparation.
                var description = "new description";
                entity.Description = description;

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Update(entity, new ElementExecuteDto()));

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
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.Delete"/>.
        /// </summary>
        [TestMethod]
        public void DeleteEntity()
        {
            try
            {
                // ------------------------------
                // Création.

                // Préparation.
                Element entity = new(0, "à supprimer", string.Empty, null, 0, false, false, false);

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Create(entity, new ElementExecuteDto()));

                // Assert.
                Assert.IsNotNull(entity);

                // ------------------------------
                // Suppression.
                var id = entity.Id;

                // Exécution.
                _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Delete(entity, new ElementExecuteDto()));

                // ------------------------------
                // Récupération, pour voir si ça existe encore.

                // Exécution.
                entity = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.GetEntity(id, new List<string>(), false));

                // Assert.
                Assert.IsNull(entity);
            }
            catch (TechnicalException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Checking methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E}.CheckEntity"/>.
        /// </summary>
        [TestMethod]
        public void CheckEntity()
        {
            try
            {
                // Préparation.
                Element entity = new(0, "aaa", "à tester", null, 0, false, false, false);

                // Exécution.
                _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true }));

                // Assert.
                Assert.IsTrue(true);
            }
            catch (BusinessException ex)
            {
                Assert.Fail(ex.BusinessMessage.MessageWithDetails);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical.CheckEntities"/>.
        /// </summary>
        [TestMethod]
        public void CheckEntities()
        {
            try
            {
                // Préparation.
                IList<Element> entities = new List<Element>();
                Element entity1 = new(0, "Tâche 1");
                entity1.State = EntityState.Added;
                entities.Add(entity1);
                Element entity2 = new(0, "Tâche 2");
                entity2.State = EntityState.Added;
                entities.Add(entity2);
                Element entity3 = new(0, "Tâche 3");
                entity3.State = EntityState.Added;
                entities.Add(entity3);

                // Exécution.
                _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.CheckEntities(entities, new ElementCheckDto() { IsCheckedAll = true }));

                // Assert.
                Assert.IsTrue(true);
            }
            catch (BusinessException ex)
            {
                Assert.Fail(ex.BusinessMessage.MessageWithDetails);
            }
        }

        #endregion

    }
}
