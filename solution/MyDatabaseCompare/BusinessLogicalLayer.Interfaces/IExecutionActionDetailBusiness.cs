using System.Collections.Generic;
using Models.Impl;
using Models.Impl.ExecuteDto;
using Models.Impl.RequestDto;

namespace BusinessLogicalLayer.Interfaces
{
    /// <summary>
    /// Méthodes permettant la recherche et le traitement de l’entité <see cref="ExecutionActionDetail"/>.
    /// </summary>
    public interface IExecutionActionDetailBusiness
    {
        #region Read methods

        /// <summary>
        /// Récupère une liste d’entités <see cref="ExecutionActionDetail" /> correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche.</param>
        /// <param name="includes">Liste des includes.</param>
        /// <returns>Liste d’entités <see cref="Movie" />.</returns>
        List<ExecutionActionDetail> GetEntities(ExecutionActionDetailRequestDto requestDto, List<string> includes);

        /// <summary>
        /// Récupère une entité <see cref="ExecutionActionDetail"/> correspondant à la clé passée en paramètre.
        /// <param name="id">Identifiant de l’entité à rechercher.</param>
        /// <param name="includes">Liste des entités enfant à récupérer.</param>
        /// <returns>Entité.</returns>
        ExecutionActionDetail GetEntity(int id, List<string> includes);

        #endregion

        #region Write methods

        /// <summary>
        /// Ajoute une entité <see cref="ExecutionActionDetail"/> en base de données.
        /// </summary>
        /// <param name="entity">Entité <see cref="Movie" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        ExecutionActionDetail InsertEntity(ExecutionActionDetail entity, BaseExecuteDto executeDto);

        /// <summary>
        /// Ajoute une liste d’entités <see cref="ExecutionActionDetail"/> en base de données.
        /// </summary>
        /// <param name="entities">Entités <see cref="ExecutionActionDetail" /> à ajouter.</returns>
        /// <param name="executeDto">Dto d’exécution.</returns>
        List<ExecutionActionDetail> InsertEntities(List<ExecutionActionDetail> entities, BaseExecuteDto executeDto);
        #endregion
    }
}