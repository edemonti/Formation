using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interface
{
    /// <summary>
    /// Interface de base permettant la recherche et le traitement d’une entité.
    /// T : Type
    /// R : RequestDto
    /// E : ExecuteDto
    /// C : CheckDto
    /// </summary>
    public interface IBaseBusinessLogical<T, R, E, C>
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
        /// <typeparam name="RT">Type du résultat retournée par la méthode.</typeparam>
        /// <param name="expression">Méthode à exécuter.</param>
        RT ExecuteMethod<RT>(Expression<Func<RT>> expression);

        #endregion

        #region Reading methods

        /// <summary>
        /// Récupère une entité correspondant à la clé passée en paramètre.
        /// </summary>
        /// <param name="Id">Clé recherchée</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>L’entité retournée par la recherche</returns>
        T GetEntityXml(int id, List<string> includes);

        /// <summary>
        /// Récupère une entité correspondant à la clé passée en paramètre.
        /// </summary>
        /// <param name="Id">Clé recherchée</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>L’entité retournée par la recherche</returns>
        T GetEntity(int id, List<string> includes, bool asNoTracking);

        /// <summary>
        /// Récupère une entité correspondant à la clé passée en paramètre.
        /// </summary>
        /// <param name="Id">Clé recherchée</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <param name="asNoTracking">??</param>
        /// <returns>L’entité retournée par la recherche</returns>
        Task<T> GetEntityAsync(int id, List<string> includes, bool asNoTracking);

        /// <summary>
        /// Récupère une liste d’entités correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>Les entités retournées par la recherche</returns>
        IEnumerable<T> GetEntitiesXml(R requestDto, List<string> includes);

        /// <summary>
        /// Récupère une liste d’entités correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <returns>Les entités retournées par la recherche</returns>
        IEnumerable<T> GetEntities(R requestDto, List<string> includes, bool asNoTracking);

        /// <summary>
        /// Récupère une liste d’entités correspondant aux paramètres du dto passé en paramètre.
        /// </summary>
        /// <param name="requestDto">Dto de recherche</param>
        /// <param name="includes">Liste des entités enfants à récupérer</param>
        /// <param name="asNoTracking">??</param>
        /// <returns>Les entités retournées par la recherche</returns>
        Task<IEnumerable<T>> GetEntitiesAsync(R requestDto, List<string> includes, bool asNoTracking);

        #endregion

        #region Writing methods

        /// <summary>
        /// Sauvegarde une liste d’entités.
        /// </summary>
        /// <param name="entities">Liste des entités à sauvegarder</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Les entités sauvegardées</returns>
        IEnumerable<T> SaveXml(IEnumerable<T> entities, E executeDto);

        /// <summary>
        /// Sauvegarde une liste d’entités.
        /// </summary>
        /// <param name="entities">Liste des entités à sauvegarder</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Les entités sauvegardées</returns>
        IEnumerable<T> Save(IEnumerable<T> entities, E executeDto);

        /// <summary>
        /// Sauvegarde une liste d’entités.
        /// </summary>
        /// <param name="entities">Liste des entités à sauvegarder</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>Les entités sauvegardées</returns>
        Task<IEnumerable<T>> SaveAsync(IEnumerable<T> entities, E executeDto);

        /// <summary>
        /// Crée un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à créer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité créée</returns>
        T CreateXml(T entity, E executeDto);

        /// <summary>
        /// Crée un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à créer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité créée</returns>
        T Create(T entity, E executeDto);

        /// <summary>
        /// Crée un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à créer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité créée</returns>
        Task<T> CreateAsync(T entity, E executeDto);

        /// <summary>
        /// Modifie un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à modifier</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité modifiée</returns>
        T UpdateXml(T entity, E executeDto);

        /// <summary>
        /// Modifie un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à modifier</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité modifiée</returns>
        T Update(T entity, E executeDto);

        /// <summary>
        /// Modifie un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à modifier</param>
        /// <param name="executeDto">Dto d’exécution</param>
        /// <returns>L’entité modifiée</returns>
        Task<T> UpdateAsync(T entity, E executeDto);

        /// <summary>
        /// Supprime un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        void DeleteXml(T entity, E executeDto);

        /// <summary>
        /// Supprime un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        void Delete(T entity, E executeDto);

        /// <summary>
        /// Supprime un enregistrement.
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        /// <param name="executeDto">Dto d’exécution</param>
        Task DeleteAsync(T entity, E executeDto);

        #endregion

        #region Checking methods

        /// <summary>
        /// Contrôle l’entitié.
        /// </summary>
        /// <param name="checkDto">Dto de contrôle</param>
        void CheckEntity(T entity, C checkDto);

        /// <summary>
        /// Contrôle les entités.
        /// </summary>
        /// <param name="checkDto">Dto de contrôle</param>
        void CheckEntities(IEnumerable<T> entities, C checkDto);

        #endregion
    }
}