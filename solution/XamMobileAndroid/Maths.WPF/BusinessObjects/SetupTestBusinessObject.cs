using System.Collections.Generic;
using Maths.WPF.Enum;
using Technical.BusinessObjects;

namespace Maths.WPF.BusinessObjects
{
    /// <summary>
    /// BusinessObject utilisé pour paramétrer le test.
    /// </summary>
    public class SetupTestBusinessObject : BaseBusinessObject
    {
        #region Properties

        /// <summary>
        /// Identifiante technique du test.
        /// </summary>
        private int _id;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        /// <summary>
        /// Nom du test.
        /// </summary>
        private string _name;
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Liste des opérations à proposer. 
        /// </summary>
        public IList<OperationType> Operations
        {
            get
            {
                var operations = new List<OperationType>();
                if (HasAddition)
                    operations.Add(OperationType.Addition);
                if (HasSubstraction)
                    operations.Add(OperationType.Substraction);
                if (HasMultiplication)
                    operations.Add(OperationType.Multiplication);
                if (HasDivision)
                    operations.Add(OperationType.Division);
                return operations;
            }
        }

        /// <summary>
        /// Flag indiquant si le peut contenir des additions.
        /// </summary>
        private bool _hasAddition;
        public bool HasAddition
        {
            get => _hasAddition;
            set => SetField(ref _hasAddition, value);
        }

        /// <summary>
        /// Flag indiquant si le peut contenir des soustractions.
        /// </summary>
        private bool _hasSubstraction;
        public bool HasSubstraction
        {
            get => _hasSubstraction;
            set => SetField(ref _hasSubstraction, value);
        }

        /// <summary>
        /// Flag indiquant si le peut contenir des multiplications.
        /// </summary>
        private bool _hasMultiplication;
        public bool HasMultiplication
        {
            get => _hasMultiplication;
            set => SetField(ref _hasMultiplication, value);
        }

        /// <summary>
        /// Flag indiquant si le peut contenir des divisions.
        /// </summary>
        private bool _hasDivision;
        public bool HasDivision
        {
            get => _hasDivision;
            set => SetField(ref _hasDivision, value);
        }

        /// <summary>
        /// Nombre d’opérations dans le test.
        /// </summary>
        private int _operationCount;
        public int OperationCount
        {
            get => _operationCount;
            set => SetField(ref _operationCount, value);
        }

        /// <summary>
        /// Nombre de réponses proposées par opération.
        /// </summary>
        private int _proposedAnswerCount;
        public int ProposedAnswerCount
        {
            get => _proposedAnswerCount;
            set => SetField(ref _proposedAnswerCount, value);
        }

        /// <summary>
        /// Liste des tables à proposer. 
        /// </summary>
        public IList<int> Tables
        {
            get
            {
                var tables = new List<int>();
                if (HasTable1)
                    tables.Add(1);
                if (HasTable2)
                    tables.Add(2);
                if (HasTable3)
                    tables.Add(3);
                if (HasTable4)
                    tables.Add(4);
                if (HasTable5)
                    tables.Add(5);
                if (HasTable6)
                    tables.Add(6);
                if (HasTable7)
                    tables.Add(7);
                if (HasTable8)
                    tables.Add(8);
                if (HasTable9)
                    tables.Add(9);
                if (HasTable10)
                    tables.Add(10);
                return tables;
            }
        }

        /// <summary>
        /// Flag indiquant si la table de 1 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable1;
        public bool HasTable1
        {
            get => _hasTable1;
            set => SetField(ref _hasTable1, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 2 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable2;
        public bool HasTable2
        {
            get => _hasTable2;
            set => SetField(ref _hasTable2, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 3 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable3;
        public bool HasTable3
        {
            get => _hasTable3;
            set => SetField(ref _hasTable3, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 4 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable4;
        public bool HasTable4
        {
            get => _hasTable4;
            set => SetField(ref _hasTable4, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 5 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable5;
        public bool HasTable5
        {
            get => _hasTable5;
            set => SetField(ref _hasTable5, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 6 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable6;
        public bool HasTable6
        {
            get => _hasTable6;
            set => SetField(ref _hasTable6, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 7 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable7;
        public bool HasTable7
        {
            get => _hasTable7;
            set => SetField(ref _hasTable7, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 8 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable8;
        public bool HasTable8
        {
            get => _hasTable8;
            set => SetField(ref _hasTable8, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 9 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable9;
        public bool HasTable9
        {
            get => _hasTable9;
            set => SetField(ref _hasTable9, value);
        }

        /// <summary>
        /// Flag indiquant si la table de 10 doit être proposée dans le test.
        /// </summary>
        private bool _hasTable10;
        public bool HasTable10
        {
            get => _hasTable10;
            set => SetField(ref _hasTable10, value);
        }

        /// <summary>
        /// Liste des nombres à proposer. 
        /// </summary>
        public IList<int> Numbers
        {
            get
            {
                var numbers = new List<int>();
                if (HasNumber0)
                    numbers.Add(0);
                if (HasNumber1)
                    numbers.Add(1);
                if (HasNumber2)
                    numbers.Add(2);
                if (HasNumber3)
                    numbers.Add(3);
                if (HasNumber4)
                    numbers.Add(4);
                if (HasNumber5)
                    numbers.Add(5);
                if (HasNumber6)
                    numbers.Add(6);
                if (HasNumber7)
                    numbers.Add(7);
                if (HasNumber8)
                    numbers.Add(8);
                if (HasNumber9)
                    numbers.Add(9);
                if (HasNumber10)
                    numbers.Add(10);
                return numbers;
            }
        }

        /// <summary>
        /// Flag indiquant si le nombre 0 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber0;
        public bool HasNumber0
        {
            get => _hasNumber0;
            set => SetField(ref _hasNumber0, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 1 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber1;
        public bool HasNumber1
        {
            get => _hasNumber1;
            set => SetField(ref _hasNumber1, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 2 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber2;
        public bool HasNumber2
        {
            get => _hasNumber2;
            set => SetField(ref _hasNumber2, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 3 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber3;
        public bool HasNumber3
        {
            get => _hasNumber3;
            set => SetField(ref _hasNumber3, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 4 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber4;
        public bool HasNumber4
        {
            get => _hasNumber4;
            set => SetField(ref _hasNumber4, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 5 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber5;
        public bool HasNumber5
        {
            get => _hasNumber5;
            set => SetField(ref _hasNumber5, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 6 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber6;
        public bool HasNumber6
        {
            get => _hasNumber6;
            set => SetField(ref _hasNumber6, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 7 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber7;
        public bool HasNumber7
        {
            get => _hasNumber7;
            set => SetField(ref _hasNumber7, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 8 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber8;
        public bool HasNumber8
        {
            get => _hasNumber8;
            set => SetField(ref _hasNumber8, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 9 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber9;
        public bool HasNumber9
        {
            get => _hasNumber9;
            set => SetField(ref _hasNumber9, value);
        }

        /// <summary>
        /// Flag indiquant si le nombre 10 doit être proposée dans le test.
        /// </summary>
        private bool _hasNumber10;
        public bool HasNumber10
        {
            get => _hasNumber10;
            set => SetField(ref _hasNumber10, value);
        }

        #endregion

        #region Constructors

        public SetupTestBusinessObject()
            : base()
        {
        }

        public SetupTestBusinessObject(int operationCount, int proposedAnswerCount)
            : base()
        {
            _operationCount = operationCount;
            _proposedAnswerCount = proposedAnswerCount;
        }

        #endregion
    }
}