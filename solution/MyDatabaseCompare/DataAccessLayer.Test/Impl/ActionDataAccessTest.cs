﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using DataAccessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;
using NUnit.Framework;

namespace DataAccessLayer.Test.Impl
{
    /// <summary>
    /// Test de la classe  <see cref="IActionDataAccess"/>.
    /// </summary>
    [TestFixture]
    public class ActionDataAccessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IActionDataAccess.
        /// </summary>
        private readonly IActionDataAccess actionDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ActionDataAccessTest()
        {
            actionDataAccess = ServiceLocator.Current.GetInstance<IActionDataAccess>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IActionDataAccess.GetEntities(ActionRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>
            {
                "ActionDetail1",
                "ActionDetail1.Action",
                "ActionDetail1.Connection",
                "ActionDetail1.Connection.ActionDetailList",
                "ActionDetail1.Query",
                "ActionDetail2",
                "ActionDetail2.Action",
                "ActionDetail2.Connection",
                "ActionDetail2.Connection.ActionDetailList",
                "ActionDetail2.Query",
                "ExecutionActionList",
                "ExecutionActionList.Action",
                "ExecutionActionList.ExecutionActionDetail1",
                "ExecutionActionList.ExecutionActionDetail2"
            };

            var requestDto = new ActionRequestDto { };
            List<Action> list = actionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionRequestDto { Id = 1, IsIdSpecified = true };
            list = actionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionRequestDto { IdActionDetail1 = 1, IsIdActionDetail1Specified = true };
            list = actionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionRequestDto { IdActionDetail2 = 2, IsIdActionDetail2Specified = true };
            list = actionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ActionRequestDto { IsActionEnabled = false, IsIsActionEnabledSpecified = true };
            list = actionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IActionDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            Action entity = actionDataAccess.GetEntity(id, includes);
            Assert.IsNotNull(entity);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IActionDataAccess.InsertEntities(List{Action}, BaseExecuteDto)(Action, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<Action>
            {
                new Action
                {
                    IsActionEnabled = true,
                    IdActionDetail1 = 1,
                    IdActionDetail2 = 2
                },
                new Action
                {
                    IsActionEnabled = false,
                    IdActionDetail1 = 3,
                    IdActionDetail2 = 4
                }
            };

            actionDataAccess.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}