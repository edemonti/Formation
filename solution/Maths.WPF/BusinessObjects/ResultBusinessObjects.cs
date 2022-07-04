using Technical.BusinessObjects;

namespace Maths.WPF.BusinessObjects
{
    /// <summary>
    /// BusinessObjects utilisé pour afficher le résultat du test.
    /// </summary>
    public class ResultBusinessObjects : BaseBusinessObject
    {
        #region Properties

        /// <summary>
        /// Appréciation.
        /// </summary>
        private string _appreciation;
        public string Appreciation
        {
            get => _appreciation;
            set => SetField(ref _appreciation, value);
        }

        /// <summary>
        /// Nombre de bonnes réponses. 
        /// </summary>
        private int _correctAnswerCount;
        public int CorrectAnswerCount
        {
            get => _correctAnswerCount;
            set => SetField(ref _correctAnswerCount, value);
        }

        /// <summary>
        /// Nombre de mauvaises réponses. 
        /// </summary>
        private int _wrongAnswerCount;
        public int WrongAnswerCount
        {
            get => _wrongAnswerCount;
            set => SetField(ref _wrongAnswerCount, value);
        }

        /// <summary>
        /// Pourcentage de réussite. 
        /// </summary>
        private double _successPercentage;
        public double SuccessPercentage
        {
            get => _successPercentage;
            set => SetField(ref _successPercentage, value);
        }

        /// <summary>
        /// Temps écoulé, au format 00:00:00.
        /// </summary>
        private string _elapsedTime;
        public string ElapsedTime
        {
            get => _elapsedTime;
            set => SetField(ref _elapsedTime, value);
        }

        /// <summary>
        /// Temps moyen écoulé par réponse, au format 00:00:00.
        /// </summary>
        private string _averageElapsedTime;
        public string AverageElapsedTime
        {
            get => _averageElapsedTime;
            set => SetField(ref _averageElapsedTime, value);
        }

        #endregion

        #region Constructors

        public ResultBusinessObjects()
            : base()
        {
        }

        public ResultBusinessObjects(string appreciation, int correctAnswerCount, int wrongAnswerCount,
            double successPercentage, string elapsedTime, string averageElapsedTime)
            : base()
        {
            _appreciation = appreciation;
            _correctAnswerCount = correctAnswerCount;
            _wrongAnswerCount = wrongAnswerCount;
            _successPercentage = successPercentage;
            _elapsedTime = elapsedTime;
            _averageElapsedTime = averageElapsedTime;
        }

        #endregion
    }
}