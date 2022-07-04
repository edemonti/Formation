using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;
using Models.ExecuteDto;
using Models.RequestDto;

namespace BusinessLogicalLayer.Interface
{
    /// <summary>
    /// Interface permettant la recherche et le traitement de l’entité <see cref="Task"/>.
    /// </summary>
    public interface ITaskBusinessLogical
    {
        #region Generic methods

        /// <summary>
        /// Exécution de la méthode passée en paramètre et retourne un TechnicalResult.
        /// </summary>
        /// <param name="action">Méthode à exécuter.</param>
        void ExecuteMethod(Action action);

        /// <summary>
        /// Exécution de la méthode passée en paramètre et retourne un TechnicalResult.
        /// </summary>
        /// <typeparam name="R">Type du résultat retournée par la méthode.</typeparam>
        /// <param name="expression">Méthode à exécuter.</param>
        /// <returns></returns>
        R ExecuteMethod<R>(Expression<Func<R>> expression);

        #endregion

        #region Reading methods

        /// <summary>
        /// Récupère une entité <see cref="Task"/> correspondant à la clé passée en paramètre.
        /// </summary>
        /// <param name="Id">Voir <see cref="Task.Id"/></param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>Entité <see cref="Task"/></returns>
        Task GetEntity(int id, List<string> includes);

        /// <summary>
        /// Récupère une liste d’entités <see cref="Task"/> correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Voir <see cref="TaskRequestDto"/></param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>Entité <see cref="Task"/></returns>
        IEnumerable<Task> GetEntities(TaskRequestDto requestDto, List<string> includes);

        #endregion

        #region Writing methods

        /// <summary>
        /// Sauvegarde une liste d’entités <see cref="Task"/> en base de données.
        /// </summary>
        /// <param name="entities">Liste d’entités <see cref="Task"/> à sauvegarder</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Entité <see cref="Task"/></returns>
        IEnumerable<Task> SaveEntities(IEnumerable<Task> entities, TaskExecuteDto executeDto);

        /// <summary>
        /// Ajoute une entité <see cref="Task"/>.
        /// </summary>
        /// <param name="entity">Entité <see cref="Task"/> à ajouter</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Entité <see cref="Task"/></returns>
        Task InsertEntity(Task entity, TaskExecuteDto executeDto);

        /// <summary>
        /// Modifie une entité <see cref="Task"/>.
        /// </summary>
        /// <param name="entity">Entité <see cref="Task"/> à modifier</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Entité <see cref="Task"/></returns>
        Task UpdateEntity(Task entity, TaskExecuteDto executeDto);

        /// <summary>
        /// Supprime une entité <see cref="Task"/>.
        /// </summary>
        /// <param name="entity">Entité <see cref="Task"/> à supprimer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        void DeleteEntity(Task entity, TaskExecuteDto executeDto);

        #endregion

        #region Checking methods

        /// <summary>
        /// Contrôle l’entité <see cref="Task"/>.
        /// </summary>
        /// <param name="checkDto">Dto de contrôle</param>
        void CheckEntity(Task entity, TaskCheckDto checkDto);

        /// <summary>
        /// Contrôle les entités <see cref="Task"/>.
        /// </summary>
        /// <param name="checkDto">Dto de contrôle</param>
        void CheckEntities(IEnumerable<Task> entities, TaskCheckDto checkDto);

        #endregion
    }
}
