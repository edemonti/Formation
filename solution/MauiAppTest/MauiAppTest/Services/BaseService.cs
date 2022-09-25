using System.Collections.ObjectModel;
using FluentValidation;
using FluentValidation.Results;

namespace MauiAppTest.Services;

public class BaseService<E, V>
    where E : class
    where V : AbstractValidator<E>
{
    #region Private fields

    private readonly IConnectivity connectivity;

    private readonly E entity;

    private readonly V validator;

    #endregion

    #region Constructors

    public BaseService(IConnectivity connectivity, V validator)
    {
        this.connectivity = connectivity;
        this.validator = validator;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Récupère une liste de T.
    /// </summary>
    public virtual async Task<ObservableCollection<E>> GetEntities()
    {
        return null;
    }

    /// <summary>
    /// Récupère une valeur de T.
    /// </summary>
    public virtual async Task<E> GetEntity()
    {
        return null;
    }

    /// <summary>
    /// Récupère une liste de T.
    /// </summary>
    public virtual async Task<ValidationResult> SaveEntity(E entity)
    {
        return new ValidationResult();
    }

    /// <summary>
    /// Récupère une liste de T.
    /// </summary>
    public virtual async Task<ValidationResult> AddEntity(E entity, bool validateData = true)
    {
        // Validation des données.
        if (validateData && validator.Validate(entity) is ValidationResult result && !result.IsValid)
            return result;

        // Ajout.

        // Sauvegarde.

        // Retour.
        return null;
    }

    /// <summary>
    /// Récupère une liste de T.
    /// </summary>
    public virtual async Task<ValidationResult> UpdateEntity(E entity, bool validateData = true)
    {
        // Validation des données.
        if (validateData && validator.Validate(entity) is ValidationResult result && !result.IsValid)
            return result;

        // Modification.

        // Sauvegarde.

        // Retour.
        return null;
    }

    /// <summary>
    /// Supprime un enregistrement..
    /// </summary>
    public virtual async Task<ValidationResult> DeleteEntity(E entity)
    {
        // Suppression.

        // Sauvegarde.

        // Retour.
        return new ValidationResult();
    }

    /// <summary>
    /// Vérifie les données avant d’ajouter ou modifier une entity.
    /// </summary>
    public virtual ValidationResult ValidateEntity(E entity)
    {
        return this.validator.Validate(entity);
    }

    #endregion
}
