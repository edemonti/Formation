using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;
using NUnit.Framework;

namespace DataAccessLayer.Test.Impl
{
    /// <summary>
    /// Test de la classe  <see cref="IConnectionDataAccess"/>.
    /// </summary>
    [TestFixture]
    public class ConnectionDataAccessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IConnectionDataAccess.
        /// </summary>
        private readonly IConnectionDataAccess connectionDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ConnectionDataAccessTest()
        {
            connectionDataAccess = ServiceLocator.Current.GetInstance<IConnectionDataAccess>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IConnectionDataAccess.GetEntities(ConnectionRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();
            var requestDto = new ConnectionRequestDto { };

            List<Connection> list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ConnectionRequestDto { Id = 1, IsIdSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ConnectionRequestDto { Name = "clear_ods_dev", IsNameSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ConnectionRequestDto { Provider = "Oracle", IsProviderSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ConnectionRequestDto { Provider = "PostgreSql", IsProviderSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
            
            requestDto = new ConnectionRequestDto { IsProviderImplemented = true, IsIsProviderImplementedSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new ConnectionRequestDto { ConnectionStringLike = "rec", IsConnectionStringLikeSpecified = true };
            list = connectionDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IConnectionDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            Connection entity = connectionDataAccess.GetEntity(id, includes);
            Assert.IsNotNull(entity);
            Assert.IsNotNull(entity.Id);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IConnectionDataAccess.InsertEntities(List{Connection}, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<Connection>
            {
                new Connection
                {
                    Name = "clear_ods_dev",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "Server=sbd-dev-pg-11;Port=5432;User Id=bi_dev_clear_ods;Password=6Ncv08DeR10FAyeKI8pr;Database=bidevclear"
                },
                new Connection
                {
                    Name = "clear_ods_rec",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "Server=sbd-dev-pg-11;Port=5432;User Id=bi_rec_clear_ods;Password=GIzrSnnunh5YbuDUbjYy;Database=birecclear"
                },
                new Connection
                {
                    Name = "clear_dwh_dev",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "server=sbd-dev-pg-11;port=5432;user id=bi_dev_clear_dwh_rw;password=1bGJJd2D6px9H164zfgq;database=bidevclear"
                },
                new Connection
                {
                    Name = "clear_dwh_rec",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "Server=sbd-dev-pg-11;Port=5432;User Id=bi_rec_clear_dwh_rw;Password=DtevJESwlOi0BNGbESpx;Database=birecclear"
                },
                new Connection
                {
                    Name = "dsn_ods_verl_dev",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "Server=sbd-dev-pg-11;Port=5432;User Id=bi_dev_verl_ods_rw;Password=dezikhfawnhaycxg8;Database=bidevadpv2"
                },
                new Connection
                {
                    Name = "dsn_ods_verl_rec",
                    Provider = "PostgreSql",
                    IsProviderImplemented = true,
                    ConnectionString = "Server=sbd-dev-pg-11;Port=5432;User Id=bi_rec_verl_ods_rw;Password=saah1khmsznl31bvz;Database=birecadpv2"
                }
            };

            connectionDataAccess.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}