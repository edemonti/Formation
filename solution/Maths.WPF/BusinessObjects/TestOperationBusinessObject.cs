using System;
using Maths.WPF.Enum;
using Technical.BusinessObjects;

namespace Maths.WPF.BusinessObjects
{
    /// <summary>
    /// BusinessObject utilisé pour afficher l’opération à résoudre.
    /// </summary>
    public class TestOperationBusinessObject : BaseBusinessObject
    {
        #region Properties

        /// <summary>
        /// Type d’opération.
        /// </summary>
        private OperationType _operationType;
        public OperationType OperationType
        {
            get => _operationType;
            set => SetField(ref _operationType, value);
        }

        /// <summary>
        /// Nombre 1 de l’opération.
        /// </summary>
        private int _operationNumber1;
        public int OperationNumber1
        {
            get => _operationNumber1;
            set => SetField(ref _operationNumber1, value);
        }

        /// <summary>
        /// Nombre 2 de l’opération.
        /// </summary>
        private int _operationNumber2;
        public int OperationNumber2
        {
            get => _operationNumber2;
            set => SetField(ref _operationNumber2, value);
        }

        /// <summary>
        /// Affichage de l’opération.
        /// </summary>
        public string OperationDisplay
        {
            get
            {
                string operation;
                switch (_operationType)
                {
                    case OperationType.Addition:
                        operation = "+";
                        break;
                    case OperationType.Substraction:
                        operation = "-";
                        break;
                    case OperationType.Multiplication:
                        operation = "x";
                        break;
                    case OperationType.Division:
                        operation = "÷";
                        break;
                    default:
                        operation = "?";
                        break;
                }
                return $"{_operationNumber1} {operation} {_operationNumber2}";
            }
        }

        /// <summary>
        /// Réponse attendue.
        /// </summary>
        private double _expectedAnswer;
        public double ExpectedAnswer
        {
            get => _expectedAnswer;
            set => SetField(ref _expectedAnswer, value);
        }

        /// <summary>
        /// Réponse 1 proposée.
        /// </summary>
        private double? _proposedAnswer1;
        public double? ProposedAnswer1
        {
            get => _proposedAnswer1;
            set => SetField(ref _proposedAnswer1, value);
        }

        /// <summary>
        /// Réponse 2 proposée.
        /// </summary>
        private double? _proposedAnswer2;
        public double? ProposedAnswer2
        {
            get => _proposedAnswer2;
            set => SetField(ref _proposedAnswer2, value);
        }

        /// <summary>
        /// Réponse 3 proposée.
        /// </summary>
        private double? _proposedAnswer3;
        public double? ProposedAnswer3
        {
            get => _proposedAnswer3;
            set => SetField(ref _proposedAnswer3, value);
        }

        /// <summary>
        /// Réponse 4 proposée.
        /// </summary>
        private double? _proposedAnswer4;
        public double? ProposedAnswer4
        {
            get => _proposedAnswer4;
            set => SetField(ref _proposedAnswer4, value);
        }

        /// <summary>
        /// Réponse.
        /// </summary>
        private double? _answer;
        public double? Answer
        {
            get => _answer;
            set => SetField(ref _answer, value);
        }

        /// <summary>
        /// Flag indiquant si la réponse est correct.
        /// </summary>
        public bool IsCorrectAnswer
        {
            get => Equals(_answer, _expectedAnswer);
        }

        #endregion

        #region Constructors

        public TestOperationBusinessObject()
            : base()
        {
        }

        public TestOperationBusinessObject(OperationType operationType, int operationNumber1, int operationNumber2)
             : base()
        {
            _operationType = operationType;
            _operationNumber1 = operationNumber1;
            _operationNumber2 = operationNumber2;
            _expectedAnswer = CalculateAnswer(operationType, operationNumber1, operationNumber2);
            _proposedAnswer1 = CalculateProposedAnswer();
            _proposedAnswer2 = CalculateProposedAnswer();
            _proposedAnswer3 = CalculateProposedAnswer();
            _proposedAnswer4 = CalculateProposedAnswer();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calcule une valeur à proposer pour l’opération passée en paramètre.
        /// </summary>
        private double CalculateProposedAnswer()
        {
            int random = new Random().Next(8) + 1;

            switch (random)
            {
                // On ajoute 1 à la réponse attendue.
                case 1:
                    return _expectedAnswer + 1;
                // On enlève 1 à la réponse attendue.
                case 2:
                    return _expectedAnswer - 1;
                // On ajoute 2 à la réponse attendue.
                case 3:
                    return _expectedAnswer + 2;
                // On enlève 2 à la réponse attendue.
                case 4:
                    return _expectedAnswer - 2;
                // On ajoute 1 au nombre 1.
                case 5:
                    return CalculateAnswer(_operationType, _operationNumber1 + 1, _operationNumber2);
                // On ajoute 1 au nombre 2.
                case 6:
                    return CalculateAnswer(_operationType, _operationNumber1, _operationNumber2 + 1);
                // On enlève 1 au nombre 1.
                case 7:
                    return CalculateAnswer(_operationType, _operationNumber1 - 1, _operationNumber2);
                // On enlève 1 au nombre 2.
                case 8:
                    return CalculateAnswer(_operationType, _operationNumber1, _operationNumber2 - 1);
            }
            return 0d;
        }

        /// <summary>
        /// Calcule le résultat de l’opération passée en paramètre.
        /// </summary>
        /// <param name="operationType">Voir <see cref="OperationType"/>.</param>
        /// <param name="operationNumber1">Voir <see cref="OperationNumber1"/>.</param>
        /// <param name="operationNumber2">Voir <see cref="OperationNumber2"/>.</param>
        /// <returns></returns>
        private double CalculateAnswer(OperationType operationType, double operationNumber1, double operationNumber2)
        {
            switch (operationType)
            {
                case OperationType.Addition:
                    return operationNumber1 + operationNumber2;
                case OperationType.Substraction:
                    return Math.Abs(operationNumber1 - operationNumber2);
                case OperationType.Multiplication:
                    return operationNumber1 * operationNumber2;
                case OperationType.Division:
                    return Math.Max(operationNumber1, operationNumber2) / Math.Min(operationNumber1, operationNumber2);
            }
            return 0d;
        }

        #endregion

    }
}