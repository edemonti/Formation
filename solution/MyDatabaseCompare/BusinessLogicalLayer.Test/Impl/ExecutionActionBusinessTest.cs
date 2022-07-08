using System;
using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Test;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;
using NUnit.Framework;

namespace BusinessLogicalLayer.Test.Impl
{
    /// <summary>
    /// Test de la classe  <see cref="IExecutionActionBusiness"/>.
    /// </summary>
    [TestFixture]
    public class ExecutionActionBusinessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IExecutionAction.
        /// </summary>
        private readonly IExecutionActionBusiness executionActionBusiness;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ExecutionActionBusinessTest()
        {
            executionActionBusiness = ServiceLocator.Current.GetInstance<IExecutionActionBusiness>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionBusiness.GetEntities(ExecutionActionRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();

            var requestDto = new ExecutionActionRequestDto { };
            List<ExecutionAction> list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionRequestDto { Id = 1, IsIdSpecified = true };
            list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionRequestDto { IdAction = 1, IsIdActionSpecified = true };
            list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionRequestDto { IdExecutionActionDetail1 = 1, IsIdExecutionActionDetail1Specified = true };
            list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionRequestDto { IdExecutionActionDetail2 = 1, IsIdExecutionActionDetail2Specified = true };
            list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionRequestDto { IdExecutionActionDetail2 = 2, IsIdExecutionActionDetail2Specified = true };
            list = executionActionBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            ExecutionAction entity = executionActionBusiness.GetEntity(id, includes);
            Assert.IsNotNull(entity);
            Assert.IsNotNull(entity.Id);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionBusiness.InsertEntities(List{ExecutionAction}, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<ExecutionAction>
            {
                new ExecutionAction
                {
                    IdAction = 1,
                    IdExecutionActionDetail1 = 1,
                    IdExecutionActionDetail2 = 2,
                    ExecutionDate = DateTime.Now,
                    ErrorMessage = string.Empty
                },
                new ExecutionAction
                {
                    IdAction = 2,
                    IdExecutionActionDetail1 = 3,
                    IdExecutionActionDetail2 = 4,
                    ExecutionDate = DateTime.Now,
                    ErrorMessage = "Problème..."
                },
            };

            executionActionBusiness.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}