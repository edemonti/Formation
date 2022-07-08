using System.ComponentModel;

namespace Maths.WPF.Enum
{
    /// <summary>
    /// Type d’opération disponible.
    /// </summary>
    public enum OperationType
    {
        [Description("Addition")]
        Addition = 0,
        [Description("Soustraction")]
        Substraction = 1,
        [Description("Multiplication")]
        Multiplication = 2,
        [Description("Division")]
        Division = 3
    }
}