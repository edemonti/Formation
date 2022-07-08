using System;
using System.Globalization;
using System.Windows.Controls;

namespace Wpf.ValidationRules
{
    /// <summary>
    /// Classe de validation de la date d’échéance.
    /// </summary>
    public class DueDateValidation : ValidationRule
    {
        #region Properties

        /// <summary>
        /// Date min possible pour une date d’échéance.
        /// </summary>
        public DateTime DateMin { get; set; }

        #endregion

        #region Methods

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime date;

            if (!DateTime.TryParse((string)value, out date))
            {
                return new ValidationResult(false, "La saisie n’est pas une date.");
            }
            if (date != DateTime.MinValue && date.CompareTo(DateMin) < 0)
            {
                return new ValidationResult(false, $"La date d’échéance doit être supérieure au {DateMin.ToShortDateString()}.");
            }

            return ValidationResult.ValidResult;
        }

        #endregion

    }
}
