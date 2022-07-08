using System.Collections.Generic;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace DataAccessLayer.Interfaces
{
    /// <summary>
    /// Méthodes permettant la recherche et le traitement de l’entité <see cref="Action"/>.
    /// </summary>
    public interface IActionDataAccess
    {
        #region Read methods

        /// <summary>
        /// Récupère une liste d’entités <see cref="Action" /> correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche.</param>
        /// <param name="includes">Liste des includes.</param>
        /// <returns>Liste d’entités <see cref="Movie" />.</returns>
        List<Action> GetEntities(ActionRequestDto requestDto, List<string> includes);

        /// <summary>
        /// Récupère une entité <see cref="Action"/> correspondant à la clé passée en paramètre.
        /// <param name="id">Identifiant de l’entité à rechercher.</param>
        /// <param name="includes">Liste des entités enfant à récupérer.</param>
        /// <returns>Entité.</returns>
        Action GetEntity(int id, List<string> includes);

        #endregion

        #region Write methods

        /// <summary>
        /// Ajoute une entité <see cref="Action"/> en base de données.
        /// </summary>
        /// <param name="entity">Entité <see cref="Movie" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        Action InsertEntity(Action entity, BaseExecuteDto executeDto);

        /// <summary>
        /// Ajoute une liste d’entités <see cref="Action"/> en base de données.
        /// </summary>
        /// <param name="entity">Entité <see cref="Movie" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        List<Action> InsertEntities(List<Action> entities, BaseExecuteDto executeDto);

        #endregion
    }
}