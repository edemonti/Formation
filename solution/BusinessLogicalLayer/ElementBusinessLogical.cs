using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicalLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using EntityFrameworkLayer.Context;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Technical.Enums;
using Technical.Exceptions;
using Technical.Messages;

namespace BusinessLogicalLayer
{
    /// <summary>
    /// Voir <see cref="IElementBusinessLogical"/>.
    /// </summary>
    public class ElementBusinessLogical : BaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>, IElementBusinessLogical
    {

        #region Private Fields

        /// <summary>
        /// Voir <see cref="IElementDataAccess"/>.
        /// </summary>
        private readonly IElementDataAccess _elementDataAccess;

        /// <summary>
        /// Liste des messages remontées lors de l’exécution des méthodes.
        /// </summary>
        private readonly IList<string> _detailMessages;

        /// <summary>
        /// Titre associé à une méthode et utilisé pour la gestion des erreurs.
        /// </summary>
        private string _errorTitle;

        /// <summary>
        /// Message associé à une méthode et utilisé pour la gestion des erreurs.
        /// </summary>
        private string _errorMessage;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ElementBusinessLogical(MyFormationContext context)
            : base(context)
        {
            _detailMessages = new List<string>();
            _elementDataAccess = new ElementDataAccess(context);
        }

        #endregion

        #region Generic methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.ExecuteMethod(Action)"/>.
        /// </summary>
        void IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.ExecuteMethod(Action action)
        {
            try
            {
                _detailMessages.Clear();
                action.Invoke();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (TechnicalException ex)
            {
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, new List<string> { ex.StackTrace }), ex);
            }
            catch (Exception ex)
            {
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, new List<string> { ex.StackTrace }), ex);
            }
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.ExecuteMethod{RT}(Expression{Func{RT}})"/>.
        /// </summary>
        RT IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.ExecuteMethod<RT>(Expression<Func<RT>> expression)
        {
            try
            {
                _detailMessages.Clear();
                return expression.Compile().Invoke();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (TechnicalException ex)
            {
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, new List<string> { ex.StackTrace }), ex);
            }
            catch (Exception ex)
            {
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, new List<string> { ex.StackTrace }), ex);
            }
        }

        #endregion

        #region Reading methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntity(int, List{string}, bool)"/>.
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntity(int id, List<string> includes, bool asNoTracking)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâche";
            _errorMessage = "Un problème a été rencontré lors de la récupération de la tâche.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntity(id, includes, asNoTracking));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntityXml(int, List{string}).
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntityXml(int id, List<string> includes)
        {

            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâche";
            _errorMessage = "Un problème a été rencontré lors de la récupération de la tâche.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntityXml(id, includes));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntityAsync(int, List{string}, bool).
        /// </summary>
        Task<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntityAsync(int id, List<string> includes, bool asNoTracking)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâche";
            _errorMessage = "Un problème a été rencontré lors de la récupération de la tâche.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntityAsync(id, includes, asNoTracking));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntities(R, List{string}, bool).
        /// </summary>
        IEnumerable<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntities(ElementRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâches";
            _errorMessage = "Un problème a été rencontré lors de la récupération des tâches.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntities(requestDto, includes, asNoTracking));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntitiesXml(R, List{string}).
        /// </summary>
        IEnumerable<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntitiesXml(ElementRequestDto requestDto, List<string> includes)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâches";
            _errorMessage = "Un problème a été rencontré lors de la récupération des tâches.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntitiesXml(requestDto, includes));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.GetEntitiesAsync(R, List{string}, bool).
        /// </summary>
        Task<IEnumerable<Element>> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.GetEntitiesAsync(ElementRequestDto requestDto, List<string> includes, bool asNoTracking)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Récupération tâches";
            _errorMessage = "Un problème a été rencontré lors de la récupération des tâches.";

            // Récupération.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.GetEntitiesAsync(requestDto, includes, asNoTracking));
        }

        #endregion

        #region Writing methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.Save(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.Save(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntities(entities, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Sauvegarde tâches";
            _errorMessage = "Un problème a été rencontré lors de la sauvegarde des tâches.";

            // Sauvegarde.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Save(entities, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.SaveAsync(IEnumerable{T}, E)"/>.
        /// </summary>
        Task<IEnumerable<Element>> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.SaveAsync(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntities(entities, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Sauvegarde tâches";
            _errorMessage = "Un problème a été rencontré lors de la sauvegarde des tâches.";

            // Sauvegarde.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.SaveAsync(entities, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.SaveXml(IEnumerable{T}, E)"/>.
        /// </summary>
        IEnumerable<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.SaveXml(IEnumerable<Element> entities, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntities(entities, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Sauvegarde tâches";
            _errorMessage = "Un problème a été rencontré lors de la sauvegarde des tâches.";

            // Sauvegarde.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.SaveXml(entities, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.Create(T, E)"/>.
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.Create(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Création tâche";
            _errorMessage = "Un problème a été rencontré lors de la création d’une tache.";

            // Insertion.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Create(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.CreateAsync(T, E)"/>.
        /// </summary>
        Task<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.CreateAsync(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Création tâche";
            _errorMessage = "Un problème a été rencontré lors de la création d’une tache.";

            // Insertion.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.CreateAsync(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.CreateXml(T, E)"/>.
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.CreateXml(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Création tâche";
            _errorMessage = "Un problème a été rencontré lors de la création d’une tache.";

            // Insertion.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.CreateXml(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.Update(T, E)"/>.
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.Update(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Modification tâche";
            _errorMessage = "Un problème a été rencontré lors de la modification de la tâche.";

            // Modification.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Update(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseDataAccess{T, R, E}.UpdateAsync(T, E)"/>.
        /// </summary>
        Task<Element> IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.UpdateAsync(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Modification tâche";
            _errorMessage = "Un problème a été rencontré lors de la modification de la tâche.";

            // Modification.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.UpdateAsync(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.UpdateXml(T, E)"/>.
        /// </summary>
        Element IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.UpdateXml(Element entity, ElementExecuteDto executeDto)
        {
            // Contrôle des champs requis.
            (this as IElementBusinessLogical).CheckEntity(entity, new ElementCheckDto() { IsCheckedAll = true });

            // Initialisation des variables d’erreur.
            _errorTitle = "Modification tâche";
            _errorMessage = "Un problème a été rencontré lors de la modification de la tâche.";

            // Modification.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.UpdateXml(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.Delete(T, E)"/>.
        /// </summary>
        void IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.Delete(Element entity, ElementExecuteDto executeDto)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Suppression tâche";
            _errorMessage = "Un problème a été rencontré lors de la suppression de la tâche.";

            // Suppression.
            _elementDataAccess.ExecuteMethod(() => _elementDataAccess.Delete(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.DeleteAsync(T, E)"/>.
        /// </summary>
        Task IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.DeleteAsync(Element entity, ElementExecuteDto executeDto)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Suppression tâche";
            _errorMessage = "Un problème a été rencontré lors de la suppression de la tâche.";

            // Suppression.
            return _elementDataAccess.ExecuteMethod(() => _elementDataAccess.DeleteAsync(entity, executeDto));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical{T, R, E, C}.DeleteXml(T, E)"/>.
        /// </summary>
        void IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.DeleteXml(Element entity, ElementExecuteDto executeDto)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Suppression tâche";
            _errorMessage = "Un problème a été rencontré lors de la suppression de la tâche.";

            // Suppression.
            _elementDataAccess.ExecuteMethod(() => _elementDataAccess.DeleteXml(entity, executeDto));
        }

        #endregion

        #region Checking methods

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical.CheckEntity(T, C)"/>.
        /// </summary>
        void IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.CheckEntity(Element entity, ElementCheckDto checkDto)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Contrôle tâche";
            _errorMessage = "Un problème a été rencontré lors du contrôle de la tâche.";

            // Contrôle.
            _detailMessages.Clear();
            if ((checkDto.IsCheckedAll || checkDto.IsCheckedName) && string.IsNullOrEmpty(entity.Name))
                _detailMessages.Add("Le nom est requis.");

            if (_detailMessages.Any())
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, _detailMessages));
        }

        /// <summary>
        /// Voir <see cref="IBaseBusinessLogical.CheckEntities(IEnumerable{T}, C)"/>.
        /// </summary>
        void IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>.CheckEntities(IEnumerable<Element> entities, ElementCheckDto checkDto)
        {
            // Initialisation des variables d’erreur.
            _errorTitle = "Contrôle tâches";
            _errorMessage = "Un problème a été rencontré lors du contrôle des tâches.";

            // Contrôle.
            _detailMessages.Clear();
            if ((checkDto.IsCheckedAll || checkDto.IsCheckedName) && entities.Any(w => string.IsNullOrEmpty(w.Name)))
                _detailMessages.Add("Le nom est requis.");

            if (_detailMessages.Any())
                throw new BusinessException(new BusinessMessage(MessageType.Error, _errorTitle, _errorMessage, _detailMessages));
        }

        #endregion

    }
}
