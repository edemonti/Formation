using System;
using System.Collections.Generic;
using System.Linq;
using Technical.BusinessObjects;

namespace Maths.WPF.BusinessObjects
{
    /// <summary>
    /// BusinessObject utilisé pour l’exécution du test.
    /// </summary>
    public class TestBusinessObject : BaseBusinessObject
    {
        #region Properties

        /// <summary>
        /// Temps écoulé depuis le début du test (en seconde).
        /// </summary>
        private int _elapsedTime;
        public int ElapsedTime
        {
            get => _elapsedTime;
            set => SetField(ref _elapsedTime, value);
        }

        /// <summary>
        /// Nombre d’opérations résolues.
        /// </summary>
        public int OperationResolvedCount
        {
            get => TestOperationBusinessObject.Count(w => w.Answer.HasValue);
        }

        /// <summary>
        /// Nombre d’opérations à résoudre.
        /// </summary>
        public int OperationCount
        {
            get => TestOperationBusinessObject.Count();
        }

        /// <summary>
        /// Avancement.
        /// </summary>
        public string Advancement
        {
            get => $"{OperationResolvedCount} / {OperationCount}";
        }

        /// <summary>
        /// Voir <see cref="TestOperationBusinessObject"/>.
        /// </summary>
        private IList<TestOperationBusinessObject> _testOperationBusinessObject;
        public IList<TestOperationBusinessObject> TestOperationBusinessObject
        {
            get => _testOperationBusinessObject;
            set => SetField(ref _testOperationBusinessObject, value);
        }

        #endregion

        #region Constructors

        public TestBusinessObject()
            : base()
        {
            _testOperationBusinessObject = new List<TestOperationBusinessObject>();
        }

        public TestBusinessObject(SetupTestBusinessObject setupTest,  IList<TestOperationBusinessObject> testOperationBusinessObject)
            : base()
        {
            var random = new Random();
            _testOperationBusinessObject = new List<TestOperationBusinessObject>();
           
            for (int i = 0; i < setupTest.OperationCount; i++)
            {
                int tableIndex = random.Next(setupTest.Tables.Count);
                int numberIndex = random.Next(setupTest.Numbers.Count);
                int operationIndex = random.Next(setupTest.Operations.Count);

                _testOperationBusinessObject.Add(
                    new TestOperationBusinessObject(
                        setupTest.Operations.ElementAt(operationIndex),
                        setupTest.Tables.ElementAt(tableIndex),
                        setupTest.Numbers.ElementAt(numberIndex)));
            }

            _testOperationBusinessObject = testOperationBusinessObject;
        }

        #endregion
    }
}
