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
    /// Test de la classe  <see cref="IQueryBusiness"/>.
    /// </summary>
    [TestFixture]
    public class QueryBusinessTest : BaseTest
    {

        #region Attributs

        /// <summary>
        /// Instance de la classe IQueryBusiness.
        /// </summary>
        private readonly IQueryBusiness queryBusiness;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur.
        /// </summary>
        public QueryBusinessTest()
        {
            queryBusiness = ServiceLocator.Current.GetInstance<IQueryBusiness>();
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Test de la méthode <see cref="IQueryBusiness.GetEntities(QueryRequestDto, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntitiesTest()
        {
            var includes = new List<string>();

            var requestDto = new QueryRequestDto { };
            List<Query> list = queryBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { Name = "src_vcdoscom_data", IsNameSpecified = true };
            list = queryBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { CommandLike = "vcdoscom", IsCommandLikeSpecified = true };
            list = queryBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);

            requestDto = new QueryRequestDto { CommandLike = "where", IsCommandLikeSpecified = true };
            list = queryBusiness.GetEntities(requestDto, includes);
            Assert.IsNotNull(list);
        }

        /// <summary>
        /// Test de la méthode <see cref="IQueryBusiness.GetEntity(int, List{string})"/>.
        /// </summary>
        [Test]
        public void GetEntityTest()
        {
            var includes = new List<string>();
            var id = 1;

            Query entity = queryBusiness.GetEntity(id, includes);
            Assert.IsNotNull(entity);
            Assert.IsNotNull(entity);
        }

        #endregion

        #region Write methods

        /// <summary>
        /// Test de la méthode <see cref="IQueryBusiness.InsertEntities(List{Query}, BaseExecuteDto)"/>.
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

            queryBusiness.InsertEntities(entities, executeDto);
            foreach (var entity in entities)
            {
                Assert.IsNotNull(entity);
                Assert.IsNotNull(entity.Id);
            }
        }

        #endregion

    }
}