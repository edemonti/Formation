using System.Collections.Generic;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Interfaces
{
    /// <summary>
    /// Méthodes permettant la recherche et le traitement de l’entité <see cref="Query"/>.
    /// </summary>
    public interface IQueryBusiness
    {
        #region Read methods

        /// <summary>
        /// Récupère une liste d’entités <see cref="Query" /> correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche.</param>
        /// <param name="includes">Liste des includes.</param>
        /// <returns>Liste d’entités <see cref="Movie" />.</returns>
        List<Query> GetEntities(QueryRequestDto requestDto, List<string> includes);

        /// <summary>
        /// Récupère une entité <see cref="Query"/> correspondant à la clé passée en paramètre.
        /// <param name="id">Identifiant de l’entité à rechercher.</param>
        /// <param name="includes">Liste des entités enfant à récupérer.</param>
        /// <returns>Entité.</returns>
        Query GetEntity(int id, List<string> includes);

        #endregion

        #region Write methods

        /// <summary>
        /// Ajoute une entité <see cref="Query"/> en base de données.
        /// </summary>
        /// <param name="entity">Entité <see cref="Query" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        Query InsertEntity(Query entity, BaseExecuteDto executeDto);

        /// <summary>
        /// Ajoute une liste d’entités <see cref="Query"/> en base de données.
        /// </summary>
        /// <param name="entities">Entités <see cref="Query" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        List<Query> InsertEntities(List<Query> entities, BaseExecuteDto executeDto);
        #endregion
    }
}