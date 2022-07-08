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
    /// Test de la classe  <see cref="IActionDetailBusiness"/>.
    /// </summary>
    [TestFixture]
    public class ActionDetailBusinessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IActionDetailBusiness.
        /// </summary>
        private readonly IActionDetailBusiness actionDetailBusiness;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ActionDetailBusinessTest()
        {
            actionDetailBusiness = ServiceLocator.Current.GetInstance<IActionDetailBusiness>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IActionDetailBusiness.GetEntities(ActionDetailRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();

            var requestDto = new ActionDetailRequestDto { };
            List<ActionDetail> list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionDetailRequestDto { Id = 1, IsIdSpecified = true };
            list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionDetailRequestDto { IdAction = 1, IsIdActionSpecified = true };
            list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionDetailRequestDto { IdConnection = 1, IsIdConnectionSpecified = true };
            list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionDetailRequestDto { IdQuery = 1, IsIdQuerySpecified = true };
            list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionDetailRequestDto { WhereLike = "1=1", IsWhereLikeSpecified = true };
            list = actionDetailBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

        }

        /// <summary>
        /// Test de la méthode <see cref="IActionDetailBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            ActionDetail entity = actionDetailBusiness.GetEntity(id, includes);
            Assert.IsNotNull(entity);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IActionDetailBusiness.InsertEntities(List{ActionDetail}, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<ActionDetail>
            {
                new ActionDetail
                {
                    IdAction = 1,
                    IdConnection = 1,
                    IdQuery = 1,
                    IsExportCsvEnabled = true,
                    IsExportXmlEnabled = false,
                    Where = "where 1=1",
                },
                new ActionDetail
                {
                    IdAction = 1,
                    IdConnection = 2,
                    IdQuery = 1,
                    IsExportCsvEnabled = true,
                    IsExportXmlEnabled = false,
                    Where = "where 1=1",
                },
                new ActionDetail
                {
                    IdAction = 2,
                    IdConnection = 1,
                    IdQuery = 2,
                    IsExportCsvEnabled = true,
                    IsExportXmlEnabled = false,
                    Where = string.Empty
                },
                new ActionDetail
                {
                    IdAction = 2,
                    IdConnection = 2,
                    IdQuery = 2,
                    IsExportCsvEnabled = true,
                    IsExportXmlEnabled = false,
                    Where = string.Empty
                }
            };

            actionDetailBusiness.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }

        }

        #endregion

    }
}