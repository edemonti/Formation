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
    /// Test de la classe  <see cref="IQueryDataAccess"/>.
    /// </summary>
    [TestFixture]
    public class QueryDataAccessTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IQueryDataAccess.
        /// </summary>
        private readonly IQueryDataAccess queryDataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public QueryDataAccessTest()
        {
            queryDataAccess = ServiceLocator.Current.GetInstance<IQueryDataAccess>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IQueryDataAccess.GetEntities(QueryRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();

            var requestDto = new QueryRequestDto { };
            List<Query> list = queryDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { Name = "src_vcdoscom_data", IsNameSpecified = true };
            list = queryDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { CommandLike = "vcdoscom", IsCommandLikeSpecified = true };
            list = queryDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { CommandLike = "where", IsCommandLikeSpecified = true };
            list = queryDataAccess.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IQueryDataAccess.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            Query entity = queryDataAccess.GetEntity(id, includes);
            Assert.IsNotNull(entity);
            Assert.IsNotNull(entity);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IQueryDataAccess.InsertEntities(List{Query}, BaseExecuteDto)"/>.
        /// </summary>
        [Test]
        [Ignore("Test déjà joué")]
        public void InsertEntitiesTest()
        {
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            var entities = new List<Query>
            {
                new Query
                {
                    Name = "src_vtactass_data",
                    Command = "select cdactass,notiers,cdpres,cdutil,flcie,flcourti,flcourtx,flcourtm,flgest,flapporc,flapporp,flretro,flreseau,lsreseau,flrgpt,cdrgpt,cdretcom,cdagent,cdste,nonat,cdgrpek,lsfamsac,lsgest,nbmdiff,mtmdiff,flcotis,nolotedi,lsutiact,flactif,cdidtva,lbcomm,nogta,noedi,cdtypreseau,cdtypreg,nocompte,cdtypact,lsoriact,cdmotifreg,flpresintern,cmpresintern,dtmodification,flsuppr from src_vtactass [%where] order by 1;"
                },
                new Query
                {
                    Name = "src_vcdoscom_data",
                    Command = "select nodoscom,notiers,nodoscrg,cdrgstat,cdtcli,cdcatcli,cdpotcli,flfraisq,flcdecis,dtqualp,dtqualc,cdintnal,cdcourti,cdacti,cmacti,cdapport,nmdestin,dtfdoss,cdfdoss,to_char(dtarchiv, 'dd/mm/yyyy') as dtarchiv,noboite,cdqualp,cdbizene,cdmetier,flaccgs,dtaccgs,nbfiliales,flfiliales,nodoscomapport,flpolicesec,cdtopetudestech,cdclimat,cdsensibilite,flanalytique,nodosrgpana,cdcoint,flsuppr from src_vcdoscom [%where] order by 1;"
                },
                new Query
                {
                    Name = "src_vcznaf_data",
                    Command = "select cdnaf,lbnaf,cdmetier,dtmodification,flsuppr from src_vcznaf [%where] order by 1;"
                },
                new Query
                {
                    Name = "src_vczsegment_data",
                    Command = "select cdsegment,cdsegmenttrad,lbsegment,ortri,dtmodification,flsuppr from src_vczsegment [%where] order by 1;"
                },
                new Query
                {
                    Name = "src_vkclient_data",
                    Command = "select nocompte,nodoscom,notiers,cdrgstat,rfclient,cdsite,cdregl,cdrappel,cdapport,dtapport,rfapport,cdalerte,nmdestin,cdtcpte,cdugcpta,mtsoldi,dtdextc,flrapadp,cdgescpt,dtdrapp,dtprapp,cdblocli,dtblocli,nostamp,lsnaf,lsconvco,cdidtva,fldecal,flrel,cdste,cdcatcli,nomandat,cdtypprel,flgroupprel,cdtypeclient,dtmodification,flsuppr from src_vkclient [%where] order by 1;"
                },
                new Query
                {
                    Name = "src_vtpolice_data",
                    Command = "select cdactass,notiers,cdpres,cdutil,flcie,flcourti,flcourtx,flcourtm,flgest,flapporc,flapporp,flretro,flreseau,lsreseau,flrgpt,cdrgpt,cdretcom,cdagent,cdste,nonat,cdgrpek,lsfamsac,lsgest,nbmdiff,mtmdiff,flcotis,nolotedi,lsutiact,flactif,cdidtva,lbcomm,nogta,noedi,cdtypreseau,cdtypreg,nocompte,cdtypact,lsoriact,cdmotifreg,flpresintern,cmpresintern,dtmodification,flsuppr from src_vtactass [%where] order by 1;"
                }
            };

            queryDataAccess.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}