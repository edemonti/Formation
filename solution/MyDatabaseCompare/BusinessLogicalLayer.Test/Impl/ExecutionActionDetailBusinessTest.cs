using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;
using NUnit.Framework;

namespace BusinessLogicalLayer.Test.Impl
{
    /// <summary>
    /// Test de la classe  <see cref="IExecutionActionDetailBusiness"/>.
    /// </summary>
    [TestFixture]
    public class ExecutionActionDetailBusinessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IExecutionAction.
        /// </summary>
        private readonly IExecutionActionDetailBusiness executionActionDetailBusiness;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ExecutionActionDetailBusinessTest()
        {
            executionActionDetailBusiness = ServiceLocator.Current.GetInstance<IExecutionActionDetailBusiness>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionDetailBusiness.GetEntities(ExecutionActionDetailRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();

            var requestDto = new ExecutionActionDetailRequestDto { };
            List<ExecutionActionDetail> list = executionActionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionDetailRequestDto { Id = 1, IsIdSpecified = true };
            list = executionActionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ExecutionActionDetailRequestDto { IdExecutionAction = 1, IsIdExecutionActionSpecified = true };
            list = executionActionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionDetailBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            ExecutionActionDetail entity = executionActionDetailBusiness.GetEntity(id, includes);
            Assert.IsNotNull(entity);
            Assert.IsNotNull(entity.Id);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IExecutionActionDetailBusiness.InsertEntities(List{ExecutionActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<ExecutionActionDetail>
            {
                new ExecutionActionDetail
                {
                    IdExecutionAction = 1,
                    DigitalSignature = "a1456b77aecf16da15538b9a4f818400",
                    Count = 11
                },
                new ExecutionActionDetail
                {
                    IdExecutionAction = 1,
                    DigitalSignature = "a1456b77aecf16da15538b9a4f818400",
                    Count = 11
                },
                new ExecutionActionDetail
                {
                    IdExecutionAction = 2,
                    DigitalSignature = "bc860edea763a2430d20db407975cb91",
                    Count = 10
                },
                new ExecutionActionDetail
                {
                    IdExecutionAction = 2,
                    DigitalSignature = "bc860edea763a2430d20db407975cb95",
                    Count = 9
                },
            };

            executionActionDetailBusiness.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}