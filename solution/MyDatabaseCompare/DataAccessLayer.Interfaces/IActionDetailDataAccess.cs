using System.Collections.Generic;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace DataAccessLayer.Interfaces
{
    /// <summary>
    /// Méthodes permettant la recherche et le traitement de l’entité <see cref="ActionDetail"/>.
    /// </summary>
    public interface IActionDetailDataAccess
    {
        #region Read methods

        /// <summary>
        /// Récupère une liste d’entités <see cref="ActionDetail" /> correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche.</param>
        /// <param name="includes">Liste des includes.</param>
        /// <returns>Liste d’entités <see cref="Movie" />.</returns>
        List<ActionDetail> GetEntities(ActionDetailRequestDto requestDto, List<string> includes);

        /// <summary>
        /// Récupère une entité <see cref="ActionDetail"/> correspondant à la clé passée en paramètre.
        /// <param name="id">Identifiant de l’entité à rechercher.</param>
        /// <param name="includes">Liste des entités enfant à récupérer.</param>
        /// <returns>Entité.</returns>
        ActionDetail GetEntity(int id, List<string> includes);

        #endregion

        #region Write methods

        /// <summary>
        /// Ajoute une entité <see cref="ActionDetail"/> en base de données.
        /// </summary>
        /// <param name="entity">Entité <see cref="Movie" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        ActionDetail InsertEntity(ActionDetail entity, BaseExecuteDto executeDto);

        /// <summary>
        /// Ajoute une liste d’entités <see cref="ActionDetail"/> en base de données.
        /// </summary>
        /// <param name="entities">Entités <see cref="ActionDetail" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        List<ActionDetail> InsertEntities(List<ActionDetail> entities, BaseExecuteDto executeDto);

        #endregion
    }
}